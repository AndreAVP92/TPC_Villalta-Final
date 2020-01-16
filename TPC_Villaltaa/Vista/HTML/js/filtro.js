$(function(){
  $('.filter').click(function(){
    $(this).addClass('active').siblings().removeClass('active');
    let valor = $(this).attr('data-nombre');
    if(valor == 'todos'){
      $('.cont-work').show('1000');
    }
    else{
      $('.cont-work').not('.' + valor).hide('1000');
      $('.cont-work').filter('.' + valor).show('1000');
    }
  });

let pasos = $('#pasos').offset().top,
    categoria = $('#categoria').offset().top,
    login = $('#login').offset().top,
    register = $('#register').offset().top;

  window.addEventListener('resize', function(){
    let pasos = $('#pasos').offset().top,
        categoria = $('#categoria').offset().top,
        login = $('#login').offset().top,
        register = $('#register').offset().top;
  });

  $('#enlace-inicio').on('click', function(e){
    e.preventDefault();
    $('html, body').animate({
      scrollTop: 0  /*para ir a la parte más alta de la página*/
    },600);
  });

  $('#enlace-categorias').on('click', function(e){
    e.preventDefault();
    $('html, body').animate({
      scrollTop: categorias-100  //para ir a la parte categoria
    },600);
  });
});
