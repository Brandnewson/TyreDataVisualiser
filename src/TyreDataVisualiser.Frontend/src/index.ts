console.log('Frontend is working!');fetch('/weatherforecast')
  .then(res => res.json())
  .then(data => console.log(data));