$(document).ready(function ()   
{  
    $('#registerFormId').validate({  
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',  
        errorPlacement: function (error, e) {  
            e.parents('.form-group > div').append(error);  
        },  
        highlight: function (e) {  
    
            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');  
            $(e).closest('.help-block').remove();  
        },  
        success: function (e) {  
            e.closest('.form-group').removeClass('has-success has-error');  
            e.closest('.help-block').remove();  
        },  
        rules: {  
            'RoleName': {  
                required: true,  
            },  
  
            'Status': {  
                required: true,  

            },  
            
        },  
        messages: {  
            'RoleName': 'Role Name Required',  
  
            'Status': {  
                required: 'Status Required',  
            },  
  
        }  
    });
    $("#adminCreate").validate({
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function (e) {

            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'adminDetails.Name': {
                required: true,
            },
            'adminDetails.Username': {
                required: true,
            },
            'adminDetails.Email': {
                required: true,
                email: true
            },

            'adminDetails.Password': {
                required: true,
                minlength: 6
            },

            'confirm_pass': {
                required: true,
                equalTo: '#adminDetails_Password'
            },
            'roles': {
                required: true,
            },
            'usercheckname': {
                required: true,
            },

        },
        messages: {
            'adminDetails.Email': 'Please enter valid email address',
            'adminDetails.Username': 'Please enter username',
            'adminDetails.Name' : 'Please enter name',
            'roles' : 'Please select role',
            'usercheckname' : 'Please select role',
            'adminDetails.Password': {
                required: 'Please provide a password',
                minlength: 'Your password must be at least 6 characters long'
            },

            'confirm_pass': {
                required: 'Please provide a password',
                minlength: 'Your password must be at least 6 characters long',
                equalTo: 'Please enter the same password as above'
            }
        }
    });
    $("#pageId").validate({
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function (e) {

            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'PageKey': {
                required: true,
            },
            'PageDescription': {
                required: true,
                minlength : 100
            },
        },
        messages: {
            'PageKey': 'Please Given Page Key',
            'PageDescription': {
                required: 'Please Given Page Description',
                minlength: 'Please Enter Atleast 100 characters'
            }
        }
    });
    $("#privillageId").validate({
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function (e) {

            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'PrivilegeName': {
                required: true,
            },
           
        },
        messages: {
            'PrivilegeName': 'Please Given Page Key',
            
        }
    });
    $("#prdtCreate").validate({
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function (e) {

            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'product.ProductName': {
                required: true,
            },
            'product.Sku': {
                required: true,
                number: true
            },
            'product.Keyword': {
                required: true,
            },

            'product.Description': {
                required: true,
                minlength: 10
            },

            'product.Prize': {
                required: true,
                number: true
            },
            'product.ImageFile': {
                required: true,
            },
            'product.Status': {
                required: true,
            },
            'category': {
                required: true,
            },

        },
        messages: {
            'product.ProductName': 'Product Name Required',
            'product.Keyword': 'Keyword Required',
            'product.ImageFile': 'Image Required',
            'product.Status': 'Status Required',
            'category': 'Category Required',
            'product.Description': {
                required: 'Description Required',
                minlength: 'Description must contain at least 10 characters long'
            },

            'product.Prize': {
                required: 'Prize Required',
                number: 'Number Required',
            },
            'product.Sku': {
                required: 'Sku Required',
                number: 'Number Required',
            }
        }
    });
});
$("#adminDetails_Username").change(function () {
    var username = $("#adminDetails_Username").val();
    $.ajax({
        type: "POST",
        url: "/Admin/CheckUsername",
        data: { user: username },
        dataType: "json",
        success: function (response) {
            var message = $("#username_msg");
            if (response) {
                //Email available.
                message.css("color", "red");
                message.html("Username is NOT available");
                $("#adminDetails_Username").val("");
                
            }
            else {
                //Email not available.
                message.css("color", "green");
                message.html("Username is available");
            }
        }
    });
});