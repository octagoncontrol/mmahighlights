'use strict';

// Dentists controller
angular.module('mmahighlights').controller('HomeCtrl', ['$scope', '$stateParams', '$http',
	function($scope, $stateParams, $http) {
		$scope.helloWorld = 'hello world';

		$http({
			method: 'GET',
			url: '/data/testing.json'
		}).then(function(response) {
			console.log(response);
		}, function(error) {
			console.log(error);
		});


	}
]);