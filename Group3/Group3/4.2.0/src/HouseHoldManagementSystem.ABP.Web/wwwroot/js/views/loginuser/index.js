(function () {
    $(function () {
        var _loginuserService = abp.services.app.login;
        $('.delete-loginuser').click(function () {
            var loginId = $(this).attr("data-loginuser-id");
            deleteLoginUser(loginId);
        });
        $('.submit-loginuser').click(function () {
            var loginname = $("#loginname").val();
            var loginpwd = $("#loginpwd").val();
            insertLoginUser(loginname, loginpwd);
        })
        $('.update-loginuser').click(function () {
            $("#close-create").show();
            $("#createnew").slideDown("slow");
        })

        function refreshRoleList() {
            location.reload(true); //reload page to see new role!
        }
        function deleteLoginUser(loginId) {
            _loginuserService.delete({
                id: loginId
            }).done(function () {
                refreshRoleList();
            });
        }
        function insertLoginUser(LoginName, LoginPwd) {
            _loginuserService.createNew({
                loginName: LoginName,
                password: LoginPwd
            }).done(function () {
                refreshRoleList();
            });
        }
    });
})();
$(document).ready(function () {
    $("#create-loginuser").click(function () {
        $("#close-create").show();
        $("#createnew").slideDown("slow");
    });
    $("#close-create").click(function () {
        $("#close-create").hide();
        $("#createnew").slideUp("slow");

    $("#update-loginuser").click(function () {
        $("#close-update").show();
        $("#update-user").slideDown("slow");
    });
    $("#update-loginuser").click(function () {
        $("#close-update").hide();
        $("#update-user").slideUp("slow");
        
    });
});