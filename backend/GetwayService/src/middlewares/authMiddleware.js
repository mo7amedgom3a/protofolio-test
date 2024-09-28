// middlewares/authMiddleware.js
const jwt = require('jsonwebtoken');
const config = require('../config/config');

const authMiddleware = (req, res, next) => {
    const url = req.url;
// if login or register skip them by using regex
    const re = new RegExp('\/(login|register)\/?$', 'g');
    const matchUrl = re.test(url);
    if (matchUrl) return next();
  const authHeader = req.headers['authorization'];
  if (!authHeader) return res.status(401).json({ message: 'Authorization header missing' });

  const token = authHeader.split(' ')[1];
  if (!token) return res.status(401).json({ message: 'Token missing' });

  try {
    // Verify token using public key
    const payload = jwt.verify(token, config.publicKey, { algorithms: ['RS256'] });
    req.user = payload;
    console.log('payload', payload);
    next();
  } catch (error) {
    return res.status(403).json({ message: 'Invalid token' });
  }
};

module.exports = authMiddleware;
