let order = 1;

var newsTitle = 0;
var newsDesc = 0;
var newsPhoto = 0;
var newsVideo = 0;
var newsSlider = 0;

// Добавление заголовка
function addTitle() {
    htmlcontent = `<div class="mb-3">
                        <div class="flextotal">
                            <label class="form-label">Заголовок</label>
                            <span class="removeform">Удалить</span>
                        </div>
                        <input data-order="${order}" data-type="heading" type="text" class="form-control" placeholder="Заголовок">
                    </div>`;
                    $('.newstitle').append(htmlcontent);
    newsTitle++;
    order++;
}

// Добавление описания
function addDesc() {
    htmlcontent = `<div class="mb-3" data-order="${order}">
                        <div class="flextotal">
                            <label class="form-label">Содержимое</label>
                            <span class="removeform">Удалить</span>
                        </div>
                        <textarea  data-order="${order}" data-type="paragraph" class="form-control" rows="3"></textarea>
                    </div>`;
                    $('.newsdesc').append(htmlcontent);
    newsDesc++;
    order++;
}

// Добавление фото
function addPhoto() {
    htmlcontent = `<div class="mb-3">
                        <div class="flextotal">
                            <label class="form-label">Загрузить фото</label>
                            <span class="removeform">Удалить</span>
                        </div>
                        <input  data-order="${order}" data-type="image" class="form-control" type="file" id="loadphoto-${newsPhoto}">
                    </div>`;
                    $('.newsphoto').append(htmlcontent);
    newsPhoto++;
    order++;
}

// Добавление видео
function addVideo() {
    htmlcontent = `<div class="mb-3">
                        <div class="flextotal">
                            <label class="form-label">Загрузить видео</label>
                            <span class="removeform">Удалить</span>
                        </div>
                        <input  data-order="${order}" data-type="video" class="form-control" type="file" id="loadvideo-${newsVideo}">
                    </div>`;
                    $('.newsvideo').append(htmlcontent);
    newsVideo++;
    order++;
}

// Добавление слайдера
function addSlider() {
    htmlcontent = ` <div class="mb-3">
                        <div class="flextotal">
                            <label class="form-label">Слайдер</label>
                            <span class="removeform">Удалить</span>
                        </div>
                        <input  data-order="${order}" data-type="slider" class="form-control" type="file" id="loadslider-${newsSlider}" multiple>
                    </div>`;
                    $('.newsslider').append(htmlcontent);
    newsSlider++;
    order++;
}

// Удаление вопроса
$(document).on('click','.removeform',function() {
    $(this).parent().parent().remove();
});
