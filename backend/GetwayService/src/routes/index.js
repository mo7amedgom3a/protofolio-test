// routes/index.js
const express = require('express');
const userRoutes = require('./userRoutes');
const { healthCheck } = require('../controllers/healthController');
const router = express.Router();

// Health Check
router.get('/health', healthCheck);

router.use('/User', userRoutes);

module.exports = router;
