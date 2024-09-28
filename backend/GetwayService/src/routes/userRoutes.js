// routes/userRoutes.js
const express = require('express');
const proxy = require('../services/proxyService');
const authMiddleware = require('../middlewares/authMiddleware');

const router = express.Router();

// Use a common base URL for the user service
const userServiceBaseUrl = 'http://localhost:5172/api/User';

router.get('/', authMiddleware, proxy(userServiceBaseUrl));
  

module.exports = router;
