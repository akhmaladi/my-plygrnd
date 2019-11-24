function onSignIn(googleUser){
    var profile = googleUser.getBasicProfile();
    $(".g-signin2").css("display", "none");
    //$(".g-data").css("display", "block");
    //$("#g-email").text(profile.getEmail());

    localStorage.setItem("isLogin", "true");
    $("#login-nav").css("display", "none");

    window.location.href = "Home/Index";
}