var express = require('express'),
	router 	= express.Router();

/**
 * Default (index) path request handler.
 */
router.get('/', function(req, res, next) {
    res.json({
        success: true,
        message: 'For API, please, use /api/<stuff>'
    });
});

module.exports = router;