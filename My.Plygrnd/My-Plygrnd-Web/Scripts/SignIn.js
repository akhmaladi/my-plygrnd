function onSignInUser(){
   
    $(".g-signin2").css("display", "none");
    
    localStorage.setItem("isLogin", "true");
    $("#login-nav").css("display", "none");

    //window.location.href = "Home/Index";
}