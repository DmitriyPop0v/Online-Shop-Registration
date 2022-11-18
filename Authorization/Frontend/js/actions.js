$(document).ready(function(){

	/*
		Here #login is login form id and this form is available in index.php page
		from here input data is sent to login.php page
		if you get login_success string from login.php page means user is logged in successfully and window.location is 
		used to redirect user from home page to profile.php page
	*/
	$("#login").on("submit",function(event){
		event.preventDefault();
		$(".overlay").show();
		$.ajax({
			url:	"https://localhost:7290/user/login",
			method:	"POST",
			data	:$("#login").serialize(),
			success	:function(data){
				$("#e_msg").html(data);
			}
		})
	})
	
	//Get User Information before checkout
	
	$("#signup_form").on("submit",function(event){
		event.preventDefault();
		$(".overlay").show();
		if (Policy.checked) {


			$.ajax(
				{
					url: "https://localhost:7290/user/registration",
					method: "POST",
					data: $("#signup_form").serialize()
					,
					success: function (data) {
						$(".overlay").hide();
						$("#signup_msg").html(data);
					},
					error: function (jqXHR, exception) {
						if (jqXHR.status == 400) {
							$("#signup_msg").html("Not all field is filled");

						}

					}
				})
		}
		else {
			$("#signup_msg").html("choose policy");
        }
	})
})






















