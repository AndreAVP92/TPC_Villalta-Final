//VARIABLES

let nav = document.getElementById('nav');
let menu = document.getElementById('enlaces');
let abrir = document.getElementById('open');
let botones = document.getElementsByClassName('btn-header');
let cerrado = true;

//variables Modal
let modal = document.getElementById('miModal');
let flex = document.getElementById('flex');
let abrirLogin = document.getElementById('enlace-login');
let cerrarLogin = document.getElementById('closem');


function menus(){
  let Desplazamiento_Actual = window.pageYOffset;

    if(Desplazamiento_Actual <= 300){
      nav.classList.remove('nav2');
      nav.className = ('nav1');
      nav.style.transition= '0.5s';
      menu.style.top = '80px';
      abrir.style.color = '#fff';
    }
    else {
      nav.classList.remove('nav1');
      nav.className = ('nav2');
      nav.style.transition= '0.5s';
      menu.style.top = '100px';
      abrir.style.color = '#000';
    }
}

function apertura(){
  if(cerrado){
    menu.style.width = '70vw';
    cerrado = false;
  }else {
    menu.style.width = '0%';
    menu.style.overflow = 'hidden';
    cerrado = true;
  }
}

////para cuando recargue la página
window.addEventListener('load', function(){
  $('#onload').fadeOut();
  $('body').removeClass('hidden');
  menus();
});
window.addEventListener('click', function(e){
  //console.log(e.target); para ver donde se hizo click
  if(cerrado==false){
    let span = document.querySelector('span');
    if(e.target !== span && e.target !== abrir){
      menu.style.width = '0%';
      menu.style.overflow = 'hidden';
      cerrado = true;
    }
  }
})
window.addEventListener('scroll', function(){
  console.log(window.pageYOffset);
  menus();
});

window.addEventListener('resize', function(){
  if(screen.width>= 700){
    cerrado = true;
    menu.style.removeProperty('overflow');
    menu.style.removeProperty('width');
  }
});

abrir.addEventListener('click', function(){
  apertura();
});

/// MODAL ///
abrirLogin.addEventListener('click', function () {
    modal.style.display = 'block';
});

cerrarLogin.addEventListener('click', function () {
    modal.style.display = 'none';
});

window.addEventListener('click', function (e) {
    if (e.target == flex) {
        modal.style.display = 'none';
    }
});