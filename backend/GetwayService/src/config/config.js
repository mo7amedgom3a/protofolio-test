// config/config.js
require('dotenv').config();
const fs = require('fs');
const path = require('path');
module.exports = {
  port: process.env.PORT || 3000,
  redisUrl: process.env.REDIS_URL || 'redis://localhost:6379',
  publicKey: fs.readFileSync(path.join(__dirname, '../../public.key'), 'utf8')
};
