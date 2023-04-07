mergeInto(LibraryManager.library, {

  	Hello: function () {
    	window.alert("Hello, world!");
    	console.log("Hello, world!");
  	},

	GiveMePlayerData: function () {
    	myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
    	myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));
  	},

  	RateGame: function () {
    
    	ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
  	},


	SaveExtern: function(date) {
    	var dateString = UTF8ToString(date);
    	var myobj = JSON.parse(dateString);
    	player.setData(myobj);
  	},

  	LoadExtern: function(){
    	player.getData().then(_date => {
        	const myJSON = JSON.stringify(_date);
        	myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
    	});
 	},

 	SetToLeaderboard : function(value){
    	ysdk.getLeaderboards()
      	.then(lb => {
        lb.setLeaderboardScore('Height', value);
      });
  	},

  GetLang: function () {
    var lang = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
    },

    AdvRestartExtern : function(){
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
          SendMessage("AudioController","MusicOff");
        },
        onRewarded: () => {
          console.log('Rewarded!');
          SendMessage("GameMechanics", "OnAdReward");          
        },
        onClose: () => {
          console.log('Video ad closed.');
          SendMessage("AudioController", "MusicOn");
          SendMessage("GameMechanics", "StartTime");
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
          SendMessage("AudioController", "MusicOn");
        }
    }
})
    },

    ShowAdv : function(){
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onOpen: () => {
          SendMessage("AudioController","MusicOff");
        },
        onClose: function(wasShown) {
          SendMessage("AudioController", "MusicOn");
        },
        onError: function(error) {
          SendMessage("AudioController", "MusicOn");
        }
    }
})
    }


  });