// services/proxyService.js
const { createProxyMiddleware } = require('http-proxy-middleware');
const services = [
  {
    route: "/api/User",
    target: 'http://localhost:5172/api/User'
  },
  {
    route: "/api/Post",
    target: 'http://localhost:5173/api/Post'
  },
  {
    route: "/api/Comment",
    target: 'http://localhost:5174/api/Comment'
  },
  {
    route: "/api/auth",
    target: 'http://localhost:5171/api/Auth'
  }
]

// Set up proxy middleware for each microservice
services.forEach(({ route, target }) => {
  // Proxy options
  const proxyOptions = {
    target,
    changeOrigin: true,
    pathRewrite: {
      [`^${route}`]: "",
    },
  };
  exports.proxy = createProxyMiddleware(proxyOptions)
});
