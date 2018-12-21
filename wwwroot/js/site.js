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



  $(".add").click(function(){
    var data=$(this).attr("data-event")
    console.log("clicked")
    $.ajax({
      url: `/showcreate/${data}`,
      method: "get"
    }).done(function(response){
      console.log(response)
      $(".modal-body").html(response)
      $('#exampleModalCenter').modal()
    })
  return false;
})

  $(document).on('click', ".CreateFlight", function(){
    var data = $(".createFlight").serialize();
    $.ajax({
      url: "createflight",
      method: "post",
      data: data,

    }).done(function(response){
      console.log(response)
    })
  })

  $(document).on('click', ".submit-trip", function(){
    
    var data = $(".createTrip").serialize();
    console.log(data)
    $.ajax({
      url: "/createtrip",
      method: "post",
      data: data,
    }).done(function(response){
      console.log(response)
      $(".addTrip").hide();
      $(".addTripForm").show()
      location.reload("../../Views/Trip/UserDashboard.cshtml" );

    })
  })

  $(document).on("click", ".hello", function() {
    console.log('click')
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
    return false
  })
})