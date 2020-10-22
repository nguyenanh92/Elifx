 $( document ).ready(function() {
     //$(".icon").click(function() {
     //    $("#showli").toggleClass("js-active");
     //});

     // Define the menu we are working with
     var menu = $('.example6');

     // Get the menus current offset
     var origOffsetY = menu.offset().top;

     /**
      * scroll
      * Perform our menu mod
      */
     function scroll() {

         // Check the menus offset. 
         if ($(window).scrollTop() >= origOffsetY) {

             //If it is indeed beyond the offset, affix it to the top.
             $(menu).addClass('navbar-fixed-top');

         } else {

             // Otherwise, un affix it.
             $(menu).removeClass('navbar-fixed-top');

         }
     }

     // Anytime the document is scrolled act on it
     document.onscroll = scroll; 
 });


 