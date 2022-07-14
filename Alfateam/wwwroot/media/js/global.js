$(document).scroll(function(e) {
  $(window).scrollTop() > 100 ? $('.nav-mobile').addClass('nav-scroll') : $('.nav-mobile').removeClass('nav-scroll');
});

$(document).scroll(function(e) {
  $(window).scrollTop() > 100 ? $('.nav-desktop').addClass('nav-scroll') : $('.nav-desktop').removeClass('nav-scroll');
});

/* --- SOUNDS CLICK --- */
var musicSpan = document.getElementById('musicSpan');
    musicSpan.addEventListener('click',function(){
    document.getElementById('sound').play()
});

var ordernow = document.querySelector('.alpha-btn');
var logotype = document.querySelector('.logotype');
var logotypefooter = document.querySelector('.logotype-footer');
var portfolio = document.querySelector('.portfolio-more');
var send = document.querySelector('.send');
var allnews = document.querySelector('.allnews');

function setupSynth() {
  window.synth = new Tone.Synth({
    oscillator: {
      type: 'sine',
      modulationFrequency: 0.5
    },
    envelope: {
      attack: 0,
      decay: 0.2,
      sustain: 0,
      release: 0.5,
    }
  }).toMaster();
}

function boopMe() {
  if (!window.synth) {
    setupSynth();
  }
  
  window.synth.triggerAttackRelease(600, '9n');
}

// FOR BUTTON LOGO
ordernow.addEventListener('touchstart', function(e) {
  e.stopPropagation();
  e.preventDefault();
  boopMe();
});
ordernow.addEventListener('mousedown', boopMe);

// FOR LOGOTYPE NAV
logotype.addEventListener('touchstart', function(e) {
  e.stopPropagation();
  e.preventDefault();
  boopMe();
});
logotype.addEventListener('mousedown', boopMe);

// FOR LOGOTYPE FOOTER
logotypefooter.addEventListener('touchstart', function(e) {
  e.stopPropagation();
  e.preventDefault();
  boopMe();
});
logotypefooter.addEventListener('mousedown', boopMe);

// FOR BUTTON SEND
send.addEventListener('touchstart', function(e) {
  e.stopPropagation();
  e.preventDefault();
  boopMe();
});
send.addEventListener('mousedown', boopMe);

// FOR BUTTON ALLNEWS
allnews.addEventListener('touchstart', function(e) {
  e.stopPropagation();
  e.preventDefault();
  boopMe();
});
allnews.addEventListener('mousedown', boopMe);

// FOR BUTTON PORTFOLIO
portfolio.addEventListener('touchstart', function(e) {
  e.stopPropagation();
  e.preventDefault();
  boopMe();
});
portfolio.addEventListener('mousedown', boopMe);

$('a[href^="#"').on('click', function() {

  let href = $(this).attr('href');

  $('html, body').animate({
      scrollTop: $(href).offset().top
  });
  return false;
});