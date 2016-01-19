'use strict';

// Dentists controller
angular.module('mmahighlights').controller('HomeCtrl', ['$scope', '$stateParams', '$http', '$sce',
	function($scope, $stateParams, $http, $sce) {
		$scope.helloWorld = 'hello world';

		$http({
			method: 'GET',
			url: '/data/testing.json'
		}).then(function(response) {
			console.log(response);
			$scope.videos = response.data.slice(0,5);
		}, function(response) {
			console.log(response);
		});

		$scope.trustUrl = function(url) {
			return $sce.trustAsResourceUrl(url);
		};

	}
]);