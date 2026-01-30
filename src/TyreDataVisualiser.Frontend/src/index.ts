import { Chart, registerables } from 'chart.js';

Chart.register(...registerables);

console.log('Tyre Data Visualiser Frontend');

// API base URL - use proxy path (Vite will forward to backend)
const API_URL = '/api';

// Chart instances
let fyVsSaChart: Chart | null = null;
let fxVsSrChart: Chart | null = null;

// Fetch test runs and display the first one
async function loadTelemetryData() {
  try {
    console.log('Fetching test runs from:', `${API_URL}/test-runs`);
    
    // Fetch all test runs
    const response = await fetch(`${API_URL}/test-runs`);
    console.log('Response status:', response.status, response.statusText);
    
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
    
    const testRuns = await response.json();
    console.log('Test runs received:', testRuns);
    
    if (!testRuns || testRuns.length === 0) {
      console.warn('No test runs found. Upload .dat files first.');
      alert('No test data found. Please upload .dat files first.');
      return;
    }
    
    console.log(`Found ${testRuns.length} test runs`);
    
    // Get the first test run with detailed data
    const firstTestRunId = testRuns[0].id;
    console.log('Fetching details for test run ID:', firstTestRunId);
    
    const detailResponse = await fetch(`${API_URL}/test-runs/${firstTestRunId}`);
    console.log('Detail response status:', detailResponse.status, detailResponse.statusText);
    
    if (!detailResponse.ok) {
      throw new Error(`HTTP error! status: ${detailResponse.status}`);
    }
    
    const testRunDetail = await detailResponse.json();
    console.log('Test run detail received:', {
      brand: testRunDetail.tyreBrand,
      model: testRunDetail.tyreModel,
      condition: testRunDetail.testCondition,
      dataPointCount: testRunDetail.dataPoints?.length || 0
    });
    
    if (!testRunDetail.dataPoints || testRunDetail.dataPoints.length === 0) {
      console.error('No data points found in test run');
      alert('Test run has no telemetry data');
      return;
    }
    
    console.log(`Data points: ${testRunDetail.dataPoints.length}`);
    console.log('Sample data point:', testRunDetail.dataPoints[0]);
    
    // Plot the data
    console.log('Plotting FY vs SA...');
    plotFyVsSa(testRunDetail);
    
    console.log('Plotting FX vs SR...');
    plotFxVsSr(testRunDetail);
    
    console.log('Charts rendered successfully');
    
  } catch (error) {
    console.error('Error loading telemetry data:', error);
    console.error('Error details:', error instanceof Error ? error.message : String(error));
    alert(`Error loading data: ${error instanceof Error ? error.message : String(error)}\n\nMake sure the API is running on http://localhost:5000`);
  }
}

// Plot Lateral Force (FY) vs Slip Angle (SA)
function plotFyVsSa(testRun: any) {
  const ctx = document.getElementById('fyVsSaChart') as HTMLCanvasElement;
  if (!ctx) return;
  
  // Extract data points
  const data = testRun.dataPoints.map((dp: any) => ({
    x: dp.sa,  // Slip Angle
    y: dp.fy   // Lateral Force
  }));
  
  // Sort by x value for proper line rendering
  data.sort((a: any, b: any) => a.x - b.x);
  
  // Destroy existing chart if it exists
  if (fyVsSaChart) {
    fyVsSaChart.destroy();
  }
  
  fyVsSaChart = new Chart(ctx, {
    type: 'scatter',
    data: {
      datasets: [{
        label: `${testRun.tyreBrand} ${testRun.tyreModel} - ${testRun.testCondition}`,
        data: data,
        backgroundColor: 'rgba(25, 118, 210, 0.6)',
        borderColor: 'rgba(25, 118, 210, 1)',
        borderWidth: 2,
        pointRadius: 2,
        showLine: true,
        tension: 0.1
      }]
    },
    options: {
      responsive: true,
      maintainAspectRatio: true,
      aspectRatio: 2,
      plugins: {
        legend: {
          display: true,
          position: 'top'
        },
        title: {
          display: true,
          text: 'Lateral Force vs Slip Angle'
        }
      },
      scales: {
        x: {
          type: 'linear',
          title: {
            display: true,
            text: 'Slip Angle (deg)'
          }
        },
        y: {
          title: {
            display: true,
            text: 'Lateral Force FY (N)'
          }
        }
      }
    }
  });
}

// Plot Longitudinal Force (FX) vs Slip Ratio (SR)
function plotFxVsSr(testRun: any) {
  const ctx = document.getElementById('fxVsSrChart') as HTMLCanvasElement;
  if (!ctx) return;
  
  // Extract data points
  const data = testRun.dataPoints.map((dp: any) => ({
    x: dp.sr,  // Slip Ratio
    y: dp.fx   // Longitudinal Force
  }));
  
  // Sort by x value for proper line rendering
  data.sort((a: any, b: any) => a.x - b.x);
  
  // Destroy existing chart if it exists
  if (fxVsSrChart) {
    fxVsSrChart.destroy();
  }
  
  fxVsSrChart = new Chart(ctx, {
    type: 'scatter',
    data: {
      datasets: [{
        label: `${testRun.tyreBrand} ${testRun.tyreModel} - ${testRun.testCondition}`,
        data: data,
        backgroundColor: 'rgba(211, 47, 47, 0.6)',
        borderColor: 'rgba(211, 47, 47, 1)',
        borderWidth: 2,
        pointRadius: 2,
        showLine: true,
        tension: 0.1
      }]
    },
    options: {
      responsive: true,
      maintainAspectRatio: true,
      aspectRatio: 2,
      plugins: {
        legend: {
          display: true,
          position: 'top'
        },
        title: {
          display: true,
          text: 'Longitudinal Force vs Slip Ratio'
        }
      },
      scales: {
        x: {
          type: 'linear',
          title: {
            display: true,
            text: 'Slip Ratio (SAE)'
          }
        },
        y: {
          title: {
            display: true,
            text: 'Longitudinal Force FX (N)'
          }
        }
      }
    }
  });
}

// Load data when page loads
loadTelemetryData();