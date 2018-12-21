function getCityState(id){
  
  $.ajax({
    url: `/getcitystate/${id}`,
    method: "get",
    success: function(res) {
      console.log("balls");
    }
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
  $(document).on('click', ".click", function(){
    console.log('click')
    getCityState(1)
  })
})

