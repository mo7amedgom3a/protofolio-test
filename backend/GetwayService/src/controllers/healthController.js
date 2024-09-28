// controllers/healthController.js
const healthCheck = (req, res) => {
    res.status(200).json({ status: 'API Gateway is healthy' });
  };
  
  module.exports = { healthCheck };
  