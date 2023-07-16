$image_crop = $('#upload-image').croppie({
	enableExif: true,
	viewport: {
		width: 200,
		height: 200,
		type: 'square'
	},
	boundary: {
		width: 300,
		height: 300
	},
	showZoomer: false,
	enableResize: true,
	enableOrientation: true,
	mouseWheelZoom: 'ctrl'
});

$(document).ready(function(){    
	$('.pctfile').change(function(ev) {
		$('.loadfile1').css('pointer-events','none');
		$('.close-file').css('display','inline-flex');
		$('.cr-boundary').css('display','flex');
		$('.text-fileupload').css('display','none');
	});
	
	$('.close-file').on('click', function() { 
		$('.pctfile').val(''); 
		$('.loadfile1').css('pointer-events','auto');
		$('.text-fileupload').css('display','flex');

		$('#upload-image').croppie('destroy');
		$image_crop=$('#upload-image').croppie($image_crop);
	});

	// $('#images').on('change', function () { 
	// 	var reader = new FileReader();
	// 	reader.onload = function (e) {
	// 		$image_crop.croppie('bind', {
	// 			url: e.target.result
	// 		}).then(function(){
	// 			console.log('jQuery bind complete');
	// 		});			
	// 	}
	// 	reader.readAsDataURL(this.files[0]);
	// });
	
	
});