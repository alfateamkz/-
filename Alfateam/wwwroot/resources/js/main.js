// КАЛЬКУЛЯТОР 
// СТАРТ
$(function() {
    $("#" + $(".rd-check-start:checked").val()).show();
    $(".rd-check-start").change(function() {
        $(".calc-content").hide();
        $("#" + $(this).val()).show();
    });
});

// ВАРИАНТ 1
$(function() {
    $("#" + $(".rd-check-mobile:checked").val()).show();
    $(".rd-check-mobile").change(function(){
        $(".content-selector").hide();
        $("#" + $(this).val()).show();
    });

    $("#" + $("#mobdev-1 option:selected").val()).show();
    $("#mobdev-1").change(function(){
        $("#step-1").hide();
        $("#step1-1").show();
    });

    $("#" + $("#mobdev-2 option:selected").val()).show();
    $("#mobdev-2").change(function(){
        $("#step-1").hide();
        $("#step1-1").show();
    });

    $("#" + $("#mobdev-3 option:selected").val()).show();
    $("#mobdev-3").change(function(){
        $("#step-1").hide();
        $("#step1-1").show();
    });

    $("#" + $("#mobdev-4 option:selected").val()).show();
    $("#mobdev-4").change(function(){
        $("#step-1").hide();
        $("#step1-1").show();
    });

    $("#" + $(".rd-check-mobile1:checked").val()).show();
    $(".rd-check-mobile1").change(function(cost2){
        $("#step1-1").hide();
        $("#step1-2").show();
        // СТАРТОВАЯ ЦЕНА
        var cost2 = 15000;

        // ВТОРОЙ БЛОК
        if (document.getElementById('mobile1-type-1').checked) {
            var cost2 = cost2 + 15000;
            console.log(cost2);
            const list = document.getElementById("cost-1-end");
            list.innerHTML = `${cost2} RUB`; 
        }else {
            var cost2 = cost2 + 0;
            console.log(cost2);
            const list = document.getElementById("cost-1-end");
            list.innerHTML = `${cost2} RUB`; 
        }
    });

    $("#" + $(".rd-check-mobile2:checked").val()).show();
    $(".rd-check-mobile2").change(function(){
        $("#step1-2").hide();
        $("#step1-3").show();
    });
});

// ВАРИАНТ 2
$(function() {
    $("#" + $(".rd-check-po:checked").val()).show();
    $(".rd-check-po").change(function(){
        $("#step-2").hide();
        $("#step2-1").show();
    });

    $("#" + $(".rd-check-po3:checked").val()).show();
    $(".rd-check-po3").change(function(cost2){
        $("#step2-1").hide();
        $("#step2-2").show();
        if (document.getElementById('po3-type-2').checked) {
            var cost2 = 25000;
            const list = document.getElementById("cost-2-end");
            list.innerHTML = `${cost2} RUB`;
        }else {
            var cost2 = 10000;
            const list = document.getElementById("cost-2-end");
            list.innerHTML = `${cost2} RUB`;  
        }
    });
});

// ВАРИАНТ 3
$(function() {
    $("#" + $(".rd-check-web:checked").val()).show();
    $(".rd-check-web").change(function(){
        $("#step-3").hide();
        $("#step3-1").show();

    });

    $("#" + $(".rd-check-web1:checked").val()).show();
    $(".rd-check-web1").change(function(cost2){
        $("#step3-1").hide();
        $("#step3-2").show();
        
        // СТАРТОВАЯ ЦЕНА
        var cost2 = 15000;
        // ПЕРВЫЙ БЛОК
        if (document.getElementById('web-type-1').checked) {
            var cost2 = cost2 + 15000;
        }else if (document.getElementById('web-type-2').checked) {
            var cost2 = cost2 + 10000;
        }else if (document.getElementById('web-type-3').checked) {
            var cost2 = cost2 + 0;
        }else if (document.getElementById('web-type-4').checked) {
            var cost2 = cost2 + 5000;
        }
        // ВТОРОЙ БЛОК
        if (document.getElementById('web1-type-1').checked) {
            var cost2 = cost2 + 2000;
            const list = document.getElementById("cost-3-end");
            list.innerHTML = `${cost2} RUB`;
        }else if (document.getElementById('web1-type-2').checked) {
            var cost2 = cost2 + 0;
            const list = document.getElementById("cost-3-end");
            list.innerHTML = `${cost2} RUB`;
        }else if (document.getElementById('web1-type-3').checked) {
            var cost2 = cost2 + 1000;
            const list = document.getElementById("cost-3-end");
            list.innerHTML = `${cost2} RUB`;
        }
    });

    $("#" + $(".rd-check-web2:checked").val()).show();
    $(".rd-check-web2").change(function(){
        $(".content-selector").hide();
        $("#" + $(this).val()).show();
    });

    $("#" + $("#web2-val1 option:selected").val()).show();
    $("#web2-val1").change(function(){
        $("#step3-2").hide();
        $("#step3-3").show();
    });

    $("#" + $("#web2-val2 option:selected").val()).show();
    $("#web2-val2").change(function(){
        $("#step3-2").hide();
        $("#step3-3").show();
    });
});

function progressBar() {
    let scroll = document.body.scrollTop || document.documentElement.scrollTop;
    let height = document.documentElement.scrollHeight - document.documentElement.clientHeight;
    let scrolled = scroll / height * 100;
    document.getElementById('scroll-fixed').style.top = scrolled + '%';
}

window.addEventListener('scroll', progressBar);


var sections = $('section')
  , nav = $('nav')
  , nav_height = nav.outerHeight();

$(window).on('scroll', function () {
  var cur_pos = $(this).scrollTop();
  
  sections.each(function() {
    var top = $(this).offset().top - nav_height,
        bottom = top + $(this).outerHeight();
    
    if (cur_pos >= top && cur_pos <= bottom) {
      nav.find('a').removeClass('active');
      sections.removeClass('active');
      
      $(this).addClass('active');
      nav.find('a[href="#'+$(this).attr('id')+'"]').addClass('active');
    }
  });
});

nav.find('a').on('click', function () {
  var $el = $(this)
    , id = $el.attr('href');
  
  $('html, body').animate({
    scrollTop: $(id).offset().top - nav_height
  }, 500);
  
  return false;
});

Revealator.effects_padding = '-150';