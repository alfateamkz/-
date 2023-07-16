jQuery(document).ready(function ($) {
 
    var maxFileSize = 100 * 1024 * 1024;
    var queue = {};
    var form = $('form#uploadImages');
    var imagesList = $('#uploadImagesList');
   
    var itemPreviewTemplate = imagesList.find('.item.template').clone();
    itemPreviewTemplate.removeClass('template');
    imagesList.find('.item.template').remove();
   
   
    $('#file-upload').on('change', function () {
      var files = this.files;
   
      for (var i = 0; i < files.length; i++) {
        var file = files[i];
   
        if ( !file.type.match(/(jpeg|jpg|png|gif|zip|rar|mp4)/) ) {
          alert( 'Фотография должна быть в формате jpg, png или gif' );
          continue;
        }
   
        if ( file.size > maxFileSize ) {
          alert( 'Загружаемый файл не должен превышать 100 МБ' );
          continue;
        }
   
        preview(files[i]);
      }
   
      this.value = '';
    });
   
    function preview(file) {
      var reader = new FileReader();
      reader.addEventListener('load', function(event) {
        var img = document.createElement('img');
   
        var itemPreview = itemPreviewTemplate.clone();
   
        if ( !file.type.match(/(jpeg|jpg|png|gif)/) ) {
         itemPreview.find('.icondef0').append('<i class="fa-solid fa-file"></i>');
        }else {
         itemPreview.find('.img-wrap img').attr('src', event.target.result);
        }
   
        itemPreview.find('.namefile0').append(file.name.slice(0,20) + '...');
        itemPreview.data('id', file.name);
   
        imagesList.append(itemPreview);
   
        queue[file.name] = file;
   
      });
      reader.readAsDataURL(file);
    }
   
    imagesList.on('click', '.delete-link', function () {
      var item = $(this).closest('.item'),
        id = item.data('id');
   
      delete queue[id];
   
      item.remove();
    });
   
   });