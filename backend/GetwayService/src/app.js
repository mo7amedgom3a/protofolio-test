// app.js
const express = require('express');
const helmet = require('helmet');
const cors = require('cors');
const morgan = require('morgan');
const authMiddleware = require('./middlewares/authMiddleware');
const swaggerUi = require('swagger-ui-express');
const swaggerDocs = require('./docs/swaggerConfig'); // Import Swagger config
const { errorHandler } = require('./middlewares/errorHandler');
const proxy = require('./services/proxyService');
const { createProxyMiddleware } = require('http-proxy-middleware');

const app = express();
app.disable('x-powered-by'); // Disable the `X-Powered-By` header
// Middlewares
app.use(helmet()); // Security headers
app.use(cors()); // Cross-origin resource sharing
app.use(morgan('combined')); // Request logging
app.use(express.json()); // Parse JSON request bodies
app.use(authMiddleware); // Authentication middleware


app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(swaggerDocs));
// Routes
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
      target: 'http://localhost:5217/api/Auth'
    }
  ]
services.forEach(({ route, target }) => {
    // Proxy options
    const proxyOptions = {
      target,
      changeOrigin: true,
      pathRewrite: {
        [`^${route}`]: "",
      },
    };
  
    // Apply rate limiting and timeout middleware before proxying
    app.use(route, createProxyMiddleware(proxyOptions));
    });

// Error handling
app.use(errorHandler);

module.exports = app;
