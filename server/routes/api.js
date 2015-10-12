var express = require('express');
var request = require('request');
var router = express.Router();

/**
 * API to for Ball Game
 */

/**
 * Creates a new User account in the Database
 * Must Pass JSON object in the body of the post request
 * body: {"user": <userId>}
 */
router.post('/create', function(req, res, next){
	var userId = req.body.user;
	var scores = App.db.collection('scores');
	var documentObject = {
		"user": userId,
		"scores": []
	};
	scores.insert(documentObject);
	res.json(documentObject);
});

/**
 * Grabs the highest scores for a certain user
 * Must Encode userId in the url
 * ?id=<userId>
 */
router.get('/scores', function(req, res, next) {
	console.log('get request');
	var query_params = req.query.id;
	var scores = App.db.collection('scores');	
	scores.find({"user": query_params}).toArray(function(err, docs) {
		if (err) {
			res.json({
		        success: false,
		        message: err
		    });
		}
		else {
			res.json({
		        success: true,
		        result: docs
		    });
		}
	});
});

/**
 * Updates highest scores for a certain user
 * Must Encode user, score, and date as a JSON object in the body of the post request
 * body: {"user":<userId>, "score":<score>, "date": <score>}
 */
router.post('/scores', function(req, res, next) {
	console.log(typeof req.body);
	var user = req.body.user;
	var score = req.body.score;
	console.log(req.body);
	console.log(user);
	console.log(score);
	var date = new Date;
	date = date.getTime();
	var scores = App.db.collection('scores');
	console.log(scores);
	scores.find({"user": user}).toArray(function(err, docs) {
		if (err) {
			res.json({
		        success: false,
		        message: err
		    });
		}
		else {
			var high_scores = docs[0].scores;
			var tmp = {score: score, date: date};
			var index = findInsertIndex(high_scores, score);
			if(index == -1 && high_scores.length < 10){
				high_scores.push(tmp);
			}
			else{
				high_scores.splice(index, 0, tmp);
				if(high_scores.length > 10){
					high_scores.pop();
				}
			}
			scores.update(
				{"user":user},
				{
					$set:{
						scores:high_scores
					}
				}
			);
			res.send("updated");
		}
	});
});

// Finds the slot at which to insert an item so the list is ordered
function findInsertIndex(array, score){
	for(var i = 0; i < array.length; i++){
		if(parseInt(array[i].score) < parseInt(score)){
			return i;
		}
	}
	return -1;
}
module.exports = router;
