
$(document).ready(function () {
    //Navbar Bawah
    //var currentPath = window.location.pathname;
    //$('.navbar-bawah a.mylink').each(function () {
    //    var $this = $(this);
    //    if (currentPath.indexOf($this.attr('href')) != -1) {
    //        $('.navbar a.mylink').removeClass('active');
    //        if ($this.parent().parent().attr('class') == 'dropdown-menu') {
    //            $this.parent().parent().prev().addClass('active');
    //        }
    //        else {
    //            $this.addClass('active');
    //        }
    //    }
    //});


    //SIDEBAR MENU
    ////set background judul menu merah di panel yang terbuka pertama kali saat load
    //$('.in').prev().children().addClass('active');
    ////$('.panel-judulMenu .active').find('.fa').toggleClass('fa-caret-right fa-caret-down');

    //$('.panel-judulMenu').click(function () {
    //    $('.judulMenu').removeClass('active');
    //    $(this).find('.judulMenu').addClass('active');   //set background merah saat judul menu di klik
    //});

    //Klik Sidebar Menu tanpa Reload
    $(document).on('click', '.menu-link', function (event) {
        event.preventDefault();
        var url = $(this).attr('href');
        //alert("This href: " + subMenuPath);
        $.ajax({
            type: "POST",
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            async: true,
            success: function (response) {
                $('.main-content').html(response);
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });

    //Klik cari menu tanpa reload
    $('#btnCari').on('submit', function (event) {
        alert('url: ' + $(this).attr('action'));
    });
});

    
