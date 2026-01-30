export default {
  root: '.',
  server: {
    port: 5173,
    proxy: {
      '/weatherforecast': {
        target: 'https://localhost:5001',
        changeOrigin: true,
        secure: false // Allow self-signed certs in dev
      }
    }
  }
}