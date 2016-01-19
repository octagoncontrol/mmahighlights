'use strict';

angular.module('mmahighlights').config(['$stateProvider',
	function($stateProvider) {

		$stateProvider.		
			state('home', {
				controller: 'HomeCtrl',
				url: '',
				templateUrl: '/templates/home.html'
			});
	}
]);