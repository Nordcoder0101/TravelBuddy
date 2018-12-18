$(document).ready(function(){
  
  $(".addFlightForm").click(function(){
    $(".addFlight").show();
    console.log("clicked")
    $.ajax({
      url: "/showcreateflight",
      method: "get"
    }).done(function(response){
      console.log(response)
      $(".addFlight").html(response)
      $(".addFlightForm").hide();
    })
  })

  $(".addTripForm").click(function () {
    $(".addTrip").show();
    console.log("clicked")
    $.ajax({
      url: "/showcreatetrip",
      method: "get"
    }).done(function (response) {
      console.log(response)
      $(".addTrip").html(response)
      $(".addTripForm").hide();
    })
  })

  $(".submit-trip").on('click', function(){
    var data = $(".createTrip").serialize();
    
    $.ajax({
      url: "/createtrip",
      method: "post",
      data: data,
    }).done(function(response){
      console.log(response)
      

    })
  })

  $(document).on("click", ".CreateFlight", function() {
    var data = $(".createFlight").serialize();
    console.log(data)
    $.ajax({
      url: "/createflight",
      method: "post",
      data: data
    }).done(function(res){
      console.log(res)
      $(".addFlightForm").show();
      $(".addFlight").hide();
    })
  })
})