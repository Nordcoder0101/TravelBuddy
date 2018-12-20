function getCityState(id){
  
  $.ajax({
    url: `/getcitystate/${id}`,
    method: "get"
  }).done(function(response) {
    // for (var i = 0; i < response.length; i++){
      console.log(response)
    
  })
}

function getLatLong(city, state){
  $.ajax({
    url: `/http://maps.googleapis.com/maps/api/geocode/json?address=${city}+${state}&sensor=true`,
    method: "get"
  }).done(function(response){
    console.log(response)
  })
}

$(document).ready(function(){
  $(".addrt").on('click', function(){
    $.ajax({
      url: "/showaddroadtrip",
      method: "get"
    }).done(function(response){
      $(".rtform").html(response);
  })
  
  })
})