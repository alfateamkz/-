var VcreateQ = 0;
var VcreateQText = 0;
var VcreateQImage = 0;
var VcreateQTextAndImage = 0;
var VcreateQEmoji = 0;
var VcreateResult = 0;

var needToHandleItems = [];


function createQ() {
    var elementhtml = `<div class="page questions" id="qust-${VcreateQ}">
                            <span class="deleteque"><i class="fa-sharp fa-solid fa-trash"></i></span>
                            <div class="copyque" onclick="cloneQuestion('qust-${VcreateQ}')"><i class="fa-regular fa-copy"></i></div>

                            <div class="row">
                                <ul class="nav nav-pills nav-fill mb-3 nav-selcontent">
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link nav-selector" onclick="createQuestionText(${VcreateQ})" type="button"><i class="fa-solid fa-cubes selector-size"></i> Варианты ответов</button>
                                    </li>
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link nav-selector" onclick="createQuestionImages(${VcreateQ})" type="button"><i class="fa-solid fa-cubes selector-size"></i> Варианты с картинкой</button>
                                    </li>
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link nav-selector" onclick="createQuestionTextAndImage(${VcreateQ})" type="button"><i class="fa-solid fa-cubes selector-size"></i> Варианты и картинка</button>
                                    </li>
                                   
                                </ul>
                                <div class="tab-content" id="question_type_${VcreateQ}">

                                </div>
                            </div>
                        </div>`;

   // <li class="nav-item" role="presentation">
   //     <button class="nav-link nav-selector" onclick="createQuestionEmoji(${VcreateQ})" type="button"><i class="fa-solid fa-cubes selector-size"></i> Эмоджи</button>
   // </li>


    $("#emojiinputdef").emojioneArea({
        pickerPosition: "bottom",
        filtersPosition: "bottom",
        tonesStyle: "checkbox"
    });

    // Удаляет выбор типа вопроса при переходе
    $(document).on('click', '.nav-link', function () {
        var id = $(this).parent().parent().parent().parent().attr("id");
        $("#" + id + " .row .nav").remove();
    });

    // При нажатии получаем ID контейнера вариантов вопроса и отправляем в другую функцию
    $(document).on('click', '.createque', function () {
        QcreateNow = $(this).parent().parent().parent().attr("id");
        console.log(`QcreateNow = ${QcreateNow}`);
        window.idqwe = QcreateNow;
    });

    $('.createq').append(elementhtml);
    VcreateQ++;
    console.log(`VcreateQ = ${VcreateQ}`);
}


function createQuestionText(id) {
    let html = `<!-- CREATE TEXT -->
                    <div class="" id="pills-text${id}" role="tabpanel" aria-labelledby="pills-text${id}-tab">
                        <div class="mb-3">
                            <label class="formlabel">Заголовок вопроса</label>
                            <div class="input-group">
                                <input type="text" data-value="QText" class="form-control" placeholder="Введите заголовок вопроса">
                            </div>
                        </div>
                        <div class="mb-3">
                            <label class="formlabel">Номер вопроса</label>
                            <div class="input-group">
                                <input data-value="QNumber" type="number" value="${VcreateQ}" class="form-control" placeholder="Введите номер вопроса">
                            </div>
                        </div>

                        <div class="contentquest qtextcontent-${id}" id="qtextcontent-${id}">
                            <div class="qcontent">
                                <div class="quegroup">
                                    <input type="text" data-value="OptionText" class="form-control" placeholder="Введите текст вопроса">
                                    <div class="colmini">
                                        <input type="text" data-value="OptionScore" class="form-control" placeholder="Кол-во баллов">
                                    </div>
                                </div>
                                
                            </div>
                        </div>

                        <div class="createnew">
                            <span class="createque" id="createvar-${id}" onclick="createQText(${id})">Создать еще один вариант</span>
                        </div>

                        <div class="mb-3">
                            <div class="form-check">
                                <input data-value="QMultipleAnswers" class="form-check-input" type="checkbox">
                                <label class="form-check-label label-transform">
                                Выбор нескольких вариантов ответа
                                </label>
                            </div>
                        </div>
                    </div>`;


    document.getElementById(`qust-${id}`).setAttribute('data-q-type', 'SimpleQuestion');
    $(`#question_type_${id}`).append(html);
    
}

function createQuestionImages(id) {
    let html = `<!-- CREATE IMAGE -->
                <div class="" id="pills-image${id}" role="tabpanel" aria-labelledby="pills-image-tab">
                    <div class="mb-3">
                        <div class="mb-3">
                            <label class="formlabel">Заголовок вопроса</label>
                            <div class="input-group">
                                <input data-value="QText" type="text" class="form-control" placeholder="Введите заголовок вопроса">
                            </div>
                        </div>
                         <div class="mb-3">
                            <label class="formlabel">Номер вопроса</label>
                            <div class="input-group">
                                <input data-value="QNumber" type="number" value="${VcreateQ}" class="form-control" placeholder="Введите номер вопроса">
                            </div>
                        </div>

                        <div class="contentquest qimagecontent-${id}" id="qimagecontent-${id}">
                            <div class="qcontent">
                                <div class="quegroup">
                                    <div class="input-group">
                                        <input type="file" data-value="OptionImage" class="form-control" id="createQImage">
                                    </div>                                                          
                                    <div class="colmini">
                                        <input type="text" data-value="OptionScore" class="form-control" placeholder="Кол-во баллов">
                                    </div>
                                </div>
                                
                            </div>
                        </div>

                        <div class="createnew">
                            <span class="createque" id="createvar-${id}" onclick="createQImage(${id})">Создать еще один вариант</span>
                        </div>

                        <div class="mb-3">
                            <div class="form-check">
                                <input data-value="QMultipleAnswers" class="form-check-input" type="checkbox">
                                <label class="form-check-label label-transform">
                                Выбор нескольких вариантов ответа
                                </label>
                            </div>
                        </div>
                    </div>
                </div>`;

    document.getElementById(`qust-${id}`).setAttribute('data-q-type', 'PictureQuestion');
    $(`#question_type_${id}`).append(html);
}

function createQuestionTextAndImage(id) {
    let html = ` <!-- CREATE TEXT AND IMAGE -->
                    <div class="" id="pills-textandimage${id}" role="tabpanel" aria-labelledby="pills-textandimage-tab">
                        <div class="mb-3">               
                            <label class="formlabel">Заголовок вопроса</label>
                            <div class="input-group">
                                <input data-value="QText" type="text" class="form-control" placeholder="Введите заголовок вопроса">
                            </div>
                        </div>
                         <div class="mb-3">
                            <label class="formlabel">Номер вопроса</label>
                            <div class="input-group">
                                <input data-value="QNumber" type="number" value="${VcreateQ}" class="form-control" placeholder="Введите номер вопроса">
                            </div>
                        </div>


                        <div class="mb-3">
                            <div class="input-group">
                                <input data-value="QImg" type="file" class="form-control">
                            </div> 
                        </div>

                        <div class="contentquest qtextimagecontent-${id}" id="qtextimagecontent-${id}">
                            <div class="qcontent">
                                <div class="quegroup">
                                 
                                    <input type="text" data-value="OptionText" class="form-control" placeholder="Введите текст вопроса">
                                    <div class="colmini">
                                        <input type="text" data-value="OptionScore" class="form-control" placeholder="Кол-во баллов">
                                    </div>
                                </div>
                                
                            </div>
                        </div>

                        <div class="createnew">
                            <span class="createque" id="createvar-${id}" onclick="createQTextAndImage(${id})">Создать еще один вариант</span>
                        </div>

                        <div class="mb-3">
                            <div class="form-check">
                                <input  data-value="QMultipleAnswers" class="form-check-input" type="checkbox">
                                <label class="form-check-label label-transform">
                                Выбор нескольких вариантов ответа
                                </label>
                            </div>
                        </div>
                    </div>`;


    document.getElementById(`qust-${id}`).setAttribute('data-q-type', 'SimplePicturedQuestion');
    $(`#question_type_${id}`).append(html);
}

function createQuestionEmoji(id) {
    let html = ` <!-- CREATE EMOJI -->
                    <div class="" id="pills-emoji${id}" role="tabpanel" aria-labelledby="pills-emoji-tab">
                        <div class="mb-3">
                            <label class="formlabel">Заголовок вопроса</label>
                            <div class="input-group">
                                <input data-value="QText" type="text" class="form-control" placeholder="Введите заголовок вопроса">
                            </div>
                        </div>
                         <div class="mb-3">
                            <label class="formlabel">Номер вопроса</label>
                            <div class="input-group">
                                <input data-value="QNumber" type="number" value="${VcreateQ}" class="form-control" placeholder="Введите номер вопроса">
                            </div>
                        </div>

                        <div class="contentquest qemojicontent-${id}" id="qemojicontent-${id}">
                            <div class="qcontent">
                                <div class="quegroup">
                                    <div class="col-emoji">
                                        <input data-value="OptionEmoji" type="text" class="form-control"  id="emojiinput-${VcreateQEmoji}" placeholder="Emoji">
                                    </div>
                                    <input type="text" data-value="OptionText" class="form-control" placeholder="Введите текст вопроса">
                                    <div class="colmini">
                                        <input type="text" data-value="OptionScore" class="form-control" placeholder="Кол-во баллов">
                                    </div>
                                </div>
                            </div>
                            <script>
                                                
                            </script>
                        </div>

                        <div class="createnew">
                            <span class="createque" id="createvar-${id}" onclick="createQEmoji(${id})">Создать еще один вариант</span>
                        </div>

                        <div class="mb-3">
                            <div class="form-check">
                                <input data-value="QMultipleAnswers" class="form-check-input" type="checkbox">
                                <label class="form-check-label label-transform">
                                Выбор нескольких вариантов ответа
                                </label>
                            </div>
                        </div>
                    </div>`;


    document.getElementById(`qust-${id}`).setAttribute('data-q-type', 'EmojiQuestion');
    $(`#question_type_${id}`).append(html);

    $("#emojiinput-" + VcreateQEmoji).emojioneArea({
        pickerPosition: "bottom",
        filtersPosition: "bottom",
        tonesStyle: "checkbox"
    });
    VcreateQEmoji++;
}


// Создание опции вопроса с вариантами ответа
function createQText(id) {
    var elementhtml = `<div class="qcontent">
                            <div class="quegroup">
                                <input type="text" id="textq-${id}" data-value="OptionText" class="form-control" placeholder="Введите текст вопроса">
                                <div class="colmini">
                                    <input type="text" data-value="OptionScore" class="form-control" placeholder="Кол-во баллов">
                                </div>
                                <a href="#" class="delete" id="removeque"><i class="fa-sharp fa-solid fa-trash"></i></a>
                            </div>
                           
                        </div>`;
    $(`#qtextcontent-${id}`).append(elementhtml);
    VcreateQText++;
}

// Создание опции вопроса с вариантами картинок
function createQImage(id) {
    var elementhtml = `<div class="qcontent">
                            <div class="quegroup">
                                <div class="input-group">
                                    <input type="file" data-value="OptionImage" class="form-control" id="createQImage-${VcreateQImage}">
                                </div> 
                                <div class="colmini">
                                    <input type="text" data-value="OptionScore" id="qimage-${id}" class="form-control" placeholder="Кол-во баллов">
                                </div>
                                <a href="#" class="delete" id="removeque"><i class="fa-sharp fa-solid fa-trash"></i></a>
                            </div>

                        </div>`;
    $(`#qimagecontent-${id}`).append(elementhtml);
    VcreateQImage++;
}

// Создание опции вопроса с вариантами ответа и картинок
function createQTextAndImage(id) {
    var elementhtml = `<div class="qcontent">
                            <div class="quegroup">
                               
                                <input type="text" data-value="OptionText" class="form-control" placeholder="Введите текст вопроса">
                                <div class="colmini">
                                    <input type="text" data-value="OptionScore" id="qimage-${id}" class="form-control" placeholder="Кол-во баллов">
                                </div>
                                <a href="#" class="delete" id="removeque"><i class="fa-sharp fa-solid fa-trash"></i></a>
                            </div>

                        </div>`;
    $(`#qtextimagecontent-${id}`).append(elementhtml);
    VcreateQTextAndImage++;
}

// Создание опции вопроса эмоджи
function createQEmoji(id) {
    var elementhtml = `<div class="qcontent">
                            <div class="quegroup">
                                <div class="col-emoji">
                                    <input data-value="OptionEmoji" id="emojiinput-${VcreateQEmoji}" type="text" class="form-control" placeholder="Emoji">
                                </div>
                                <input type="text" data-value="OptionText" class="form-control" placeholder="Введите текст">
                                <div class="colmini">
                                    <input type="text" data-value="OptionScore" class="form-control" placeholder="Кол-во баллов">
                                </div>
                                <a href="#" class="delete" id="removeque"><i class="fa-sharp fa-solid fa-trash"></i></a>
                            </div>

                        </div>`;
    $(`#qemojicontent-${id}`).append(elementhtml);

    $("#emojiinput-" + VcreateQEmoji).emojioneArea({
        pickerPosition: "bottom",
        filtersPosition: "bottom",
        tonesStyle: "checkbox"
    });
    VcreateQEmoji++;
}



//Клонирование вопроса
function cloneQuestion(blockId) {

    let block = document.getElementById(blockId);
    let clone = block.cloneNode(true);

    VcreateQ++;
    clone.setAttribute('id', `qust-${VcreateQ}`);
    clone.setAttribute('data-id', '0');
    clone.querySelector('[data-value="QNumber"]').value = VcreateQ;
    clone.querySelector('.deleteque').removeAttribute('onclick');


    //Варианты ответов

    //Удаление обработчика удаления
    let deleteBtns = clone.querySelectorAll('.delete');
    for (let i = 0; i < deleteBtns.length; i++) {
        deleteBtns[i].removeAttribute('onclick');
    }

    let qOptions = clone.querySelectorAll('.qcontent');
    for (let i = 0; i < qOptions.length; i++) {
        qOptions[i].setAttribute('data-id','0');
    }


    $('.createq').append(clone);
}



// Удаление вопроса
$(document).on('click','#removeque',function() {
    $(this).parent().parent().remove();
});

// Удаление результата
$(document).on('click','.removeresult',function() {
    $(this).parent().remove();
});

// Удаление созданного вопроса
$(document).on('click','.deleteque',function() {
    $(this).parent().remove();
});

// Загрузка файла общая
$(document).ready(function() {
    $(".loaderform").change(function() {
        var f_name = [];
        for(var i = 0; i < $(this).get(0).files.length; ++i) {
            f_name.push($(this).get(0).files[i].name);
        }
        $(".filenameloader").val(f_name.join(", "));
    });

});

$('.nav-st').click(function() {
    $(".nav-selcontentl").css("display", "none");
});

$(document).on('click','.nav-st',function() {
    $('.nav-selcontentl').remove();
});



let questionIdsToDelete = [];
let optionIdsToDelete = [];


async function loadQuestions(id) {

    await fetch(document.location.origin + `/GetTestQuestions?id=${id}`)
        .then((response) => {
            return response.json();
        })
        .then((data) => {

            console.log(data);
            for (let i = 0; i < data.length; i++) {

                let question = data[i];
                loadQuestion(question);
            }
        });

   
}

function loadQuestion(question) {
    var elementhtml = `<div class="page questions" data-id="${question.id}" id="qust-${VcreateQ}">
                            <span class="deleteque" onclick="pushQuestionIdToDelete(${question.id})"><i class="fa-sharp fa-solid fa-trash"></i></span>
                            <div class="copyque" onclick="cloneQuestion('qust-${VcreateQ}')"><i class="fa-regular fa-copy"></i></div>
                            <div class="row">
                               
                                <div class="tab-content" id="question_type_${VcreateQ}">

                                </div>
                            </div>
                        </div>`;

    //
    $("#emojiinputdef").emojioneArea({
        pickerPosition: "bottom",
        filtersPosition: "bottom",
        tonesStyle: "checkbox"
    });

    // Удаляет выбор типа вопроса при переходе
    $(document).on('click', '.nav-link', function () {
        var id = $(this).parent().parent().parent().parent().attr("id");
        $("#" + id + " .row .nav").remove();
    });

    // При нажатии получаем ID контейнера вариантов вопроса и отправляем в другую функцию
    $(document).on('click', '.createque', function () {
        QcreateNow = $(this).parent().parent().parent().attr("id");
        console.log(`QcreateNow = ${QcreateNow}`);
        window.idqwe = QcreateNow;
    });

    $('.createq').append(elementhtml);
  

    document.getElementById(`qust-${VcreateQ}`).setAttribute('data-q-type', question.discriminator);

    if (question.discriminator == 'SimpleQuestion') {
        loadQuestionText(VcreateQ, question);
    }
    else if (question.discriminator == 'PictureQuestion') {
        loadQuestionImages(VcreateQ, question);
    }
    else if (question.discriminator == 'SimplePicturedQuestion') {
        loadQuestionTextAndImage(VcreateQ, question);
    }
    else if (question.discriminator == 'EmojiQuestion') {
        loadQuestionEmoji(VcreateQ, question);
    }

    VcreateQ++;
    console.log(`VcreateQ = ${VcreateQ}`);
}


function loadQuestionText(id, question) {

    let html = `<!-- CREATE TEXT -->
                    <div class="" id="pills-text${id}" role="tabpanel" aria-labelledby="pills-text${id}-tab">
                        <div class="mb-3">
                            <label class="formlabel">Заголовок вопроса</label>
                            <div class="input-group">
                                <input data-value="QText" type="text" value="${question.text}" class="form-control" placeholder="Введите заголовок вопроса">
                            </div>
                        </div>

                        <div class="mb-3">
                            <label class="formlabel">Номер вопроса</label>
                            <div class="input-group">
                                <input data-value="QNumber" type="number" value="${question.number}" class="form-control" placeholder="Введите номер вопроса">
                            </div>
                        </div>

                        <div class="contentquest qtextcontent-${id}" id="qtextcontent-${id}">
                        
                        </div>

                        <div class="createnew">
                            <span class="createque" id="createvar-${id}" onclick="createQText(${id})">Создать еще один вариант</span>
                        </div>

                        <div class="mb-3">
                            <div class="form-check">
                                <input data-value="QMultipleAnswers" class="form-check-input" type="checkbox">
                                <label class="form-check-label label-transform">
                                Выбор нескольких вариантов ответа
                                </label>
                            </div>
                        </div>
                    </div>`;
    $(`#question_type_${id}`).append(html);

    document.getElementById(`question_type_${id}`).querySelector('[data-value="QMultipleAnswers"]').checked = question.multipleAnswers;



    for (let i = 0; i < question.options.length; i++) {

        let option = question.options[i];
        loadQText(id, option);
    }
}

function loadQuestionImages(id, question) {
    let html = `<!-- CREATE IMAGE -->
                <div class="" id="pills-image${id}" role="tabpanel" aria-labelledby="pills-image-tab">
                    <div class="mb-3">
                        <div class="mb-3">
                            <label class="formlabel">Заголовок вопроса</label>
                            <div class="input-group">
                                <input data-value="QText" type="text" value="${question.text}" class="form-control" placeholder="Введите заголовок вопроса">
                            </div>
                        </div>

                         <div class="mb-3">
                            <label class="formlabel">Номер вопроса</label>
                            <div class="input-group">
                                <input data-value="QNumber" type="number" value="${question.number}" class="form-control" placeholder="Введите номер вопроса">
                            </div>
                        </div>

                        <div class="contentquest qimagecontent-${id}" id="qimagecontent-${id}">



                        </div>

                        <div class="createnew">
                            <span class="createque" id="createvar-${id}" onclick="createQImage(${id})">Создать еще один вариант</span>
                        </div>

                        <div class="mb-3">
                            <div class="form-check">
                                <input data-value="QMultipleAnswers" class="form-check-input" type="checkbox">
                                <label class="form-check-label label-transform">
                                Выбор нескольких вариантов ответа
                                </label>
                            </div>
                        </div>
                    </div>
                </div>`;
    $(`#question_type_${id}`).append(html);

    document.getElementById(`question_type_${id}`).querySelector('[data-value="QMultipleAnswers"]').checked = question.multipleAnswers;

    for (let i = 0; i < question.options.length; i++) {

        let option = question.options[i];
        loadQImage(id, option);
    }
}

function loadQuestionTextAndImage(id, question) {
    let html = ` <!-- CREATE TEXT AND IMAGE -->
                    <div class="" id="pills-textandimage${id}" role="tabpanel" aria-labelledby="pills-textandimage-tab">
                        <div class="mb-3">               
                            <label class="formlabel">Заголовок вопроса</label>
                            <div class="input-group">
                                <input data-value="QText" type="text" value="${question.text}" class="form-control" placeholder="Введите заголовок вопроса">
                            </div>
                        </div>

                         <div class="mb-3">
                            <label class="formlabel">Номер вопроса</label>
                            <div class="input-group">
                                <input data-value="QNumber" type="number" value="${question.number}" class="form-control" placeholder="Введите номер вопроса">
                            </div>
                        </div>

                        <div class="mb-3">
                            <div class="input-group">
                                <input type="file" data-value="QImg" data-imgPath="${question.imgPath}" class="form-control">
                            </div> 
                        </div>

                        <div class="contentquest qtextimagecontent-${id}" id="qtextimagecontent-${id}">
                            
                        </div>

                        <div class="createnew">
                            <span class="createque" id="createvar-${id}" onclick="createQTextAndImage(${id})">Создать еще один вариант</span>
                        </div>

                        <div class="mb-3">
                            <div class="form-check">
                                <input data-value="QMultipleAnswers" class="form-check-input" type="checkbox">
                                <label class="form-check-label label-transform">
                                Выбор нескольких вариантов ответа
                                </label>
                            </div>
                        </div>
                    </div>`;
    $(`#question_type_${id}`).append(html);

    document.getElementById(`question_type_${id}`).querySelector('[data-value="QMultipleAnswers"]').checked = question.multipleAnswers;

    for (let i = 0; i < question.options.length; i++) {

        let option = question.options[i];
        loadQTextAndImage(id, option);
    }
}

function loadQuestionEmoji(id, question) {
    let html = ` <!-- CREATE EMOJI -->
                    <div class="" id="pills-emoji${id}" role="tabpanel" aria-labelledby="pills-emoji-tab">
                        <div class="mb-3">
                            <label class="formlabel">Заголовок вопроса</label>
                            <div class="input-group">
                                <input data-value="QText" type="text" value="${question.text}" class="form-control" placeholder="Введите заголовок вопроса">
                            </div>
                        </div>

                         <div class="mb-3">
                            <label class="formlabel">Номер вопроса</label>
                            <div class="input-group">
                                <input data-value="QNumber" type="number" value="${question.number}" class="form-control" placeholder="Введите номер вопроса">
                            </div>
                        </div>

                        <div class="contentquest qemojicontent-${id}" id="qemojicontent-${id}">
                            
                        </div>

                        <div class="createnew">
                            <span class="createque" id="createvar-${id}" onclick="createQEmoji(${id})">Создать еще один вариант</span>
                        </div>

                        <div class="mb-3">
                            <div class="form-check">
                                <input data-value="QMultipleAnswers" class="form-check-input" type="checkbox">
                                <label class="form-check-label label-transform">
                                Выбор нескольких вариантов ответа
                                </label>
                            </div>
                        </div>
                    </div>`;
    $(`#question_type_${id}`).append(html);

    document.getElementById(`question_type_${id}`).querySelector('[data-value="QMultipleAnswers"]').checked = question.multipleAnswers;

    $("#emojiinput-" + VcreateQEmoji).emojioneArea({
        pickerPosition: "bottom",
        filtersPosition: "bottom",
        tonesStyle: "checkbox"
    });
    VcreateQEmoji++;

    for (let i = 0; i < question.options.length; i++) {

        let option = question.options[i];
        loadQEmoji(id, option);
    }

}



// Создание опции вопроса с вариантами ответа
function loadQText(id,option) {
    var elementhtml = `<div class="qcontent" data-id="${option.id}">
                            <div class="quegroup">
                                <input type="text" data-value="OptionText" id="textq-${id}" value="${option.text}" class="form-control" placeholder="Введите текст вопроса">
                                <div class="colmini">
                                    <input type="text" data-value="OptionScore" value="${option.score}" class="form-control" placeholder="Кол-во баллов">
                                </div>
                                <span onclick="pushQOptionIdToDelete(${option.id})" class="delete" id="removeque"><i class="fa-sharp fa-solid fa-trash"></i></span>
                            </div>
                           
                        </div>`;
    $(`#qtextcontent-${id}`).append(elementhtml);
    VcreateQText++;
}

// Создание опции вопроса с вариантами картинок
function loadQImage(id, option) {
    var elementhtml = `<div class="qcontent"  data-id="${option.id}">
                            <div class="quegroup">
                                <div class="input-group">
                                    <input type="file" data-value="OptionImage" data-imgPath="${option.imgPath}" class="form-control" id="createQImage-${VcreateQImage}">
                                </div> 
                                <div class="colmini">
                                    <input type="text" data-value="OptionScore" value="${option.score}" id="qimage-${id}" class="form-control" placeholder="Кол-во баллов">
                                </div>
                                <span onclick="pushQOptionIdToDelete(${option.id})" class="delete" id="removeque"><i class="fa-sharp fa-solid fa-trash"></i></span>
                            </div>

                        </div>`;
    $(`#qimagecontent-${id}`).append(elementhtml);
    VcreateQImage++;
}

// Создание опции вопроса с вариантами ответа и картинок
function loadQTextAndImage(id, option) {
    var elementhtml = `<div class="qcontent"  data-id="${option.id}">
                            <div class="quegroup">
                               
                                <input type="text" data-value="OptionText" value="${option.text}" class="form-control" placeholder="Введите текст вопроса">
                                <div class="colmini">
                                    <input type="text" data-value="OptionScore" value="${option.score}" id="qimage-${id}" class="form-control" placeholder="Кол-во баллов">
                                </div>
                                <span onclick="pushQOptionIdToDelete(${option.id})" class="delete" id="removeque"><i class="fa-sharp fa-solid fa-trash"></i></span>
                            </div>

                        </div>`;
    $(`#qtextimagecontent-${id}`).append(elementhtml);
    VcreateQTextAndImage++;
}

// Создание опции вопроса эмоджи
function loadQEmoji(id, option) {
    var elementhtml = `<div class="qcontent" data-id="${option.id}">
                            <div class="quegroup">
                                <div class="col-emoji">
                                    <input data-value="OptionEmoji" id="emojiinput-${VcreateQEmoji}" value="${option.emoji}" type="text" class="form-control" placeholder="Emoji">
                                </div>
                                <input type="text" data-value="OptionText" class="form-control" value="${option.text}" placeholder="Введите текст">
                                <div class="colmini">
                                    <input type="text" data-value="OptionScore" value="${option.score}" class="form-control" placeholder="Кол-во баллов">
                                </div>
                                <span onclick="pushQOptionIdToDelete(${option.id})" class="delete" id="removeque"><i class="fa-sharp fa-solid fa-trash"></i></span>
                            </div>

                        </div>`;
    $(`#qemojicontent-${id}`).append(elementhtml);

    $("#emojiinput-" + VcreateQEmoji).emojioneArea({
        pickerPosition: "bottom",
        filtersPosition: "bottom",
        tonesStyle: "checkbox"
    });
    VcreateQEmoji++;
}



function pushQuestionIdToDelete(id) {
    questionIdsToDelete.push(new Number(id));
}
function pushQOptionIdToDelete(id) {
    optionIdsToDelete.push(new Number(id));
}

let filesCounter = 0;
async function saveQuestions(testId) {

    let formData = new FormData();
    filesCounter = 0;
    let questions = [];

    let questionContainers = document.querySelectorAll('.page.questions');

    for (let i = 0; i < questionContainers.length; i++) {

        let question = {
            Id: 0,
            Number: 0,
            Text: '',
            ImgPath: '',
            Discriminator: '',
            FilesFromFrontend: 0,
            Options: [],
            MultipleAnswers: false
        };


        let qContainer = questionContainers[i];
        let optionContainers = qContainer.querySelectorAll('.qcontent');

        if (qContainer.hasAttribute('data-id')) {
            question.Id = new Number(qContainer.getAttribute('data-id'));
        }


        question.MultipleAnswers = qContainer.querySelector('[data-value="QMultipleAnswers"]').checked;
        question.Number = new Number(qContainer.querySelector('[data-value="QNumber"]').value);
        question.Text = qContainer.querySelector('[data-value="QText"]').value;
        let qType = qContainer.getAttribute('data-q-type');
        question.Discriminator = qType;


        let questionOptionDiscriminator = '';

        if (qType == 'SimplePicturedQuestion') {
         

            let qImage = qContainer.querySelector('[data-value="QImg"]');

            if (qImage.hasAttribute('data-imgPath')) {
                question.ImgPath = qImage.getAttribute('data-imgPath');               
            }
            question.FilesFromFrontend = qImage.files.length;

            if (question.FilesFromFrontend > 0) {
                formData.append(`file_${filesCounter++}`, qImage.files[0]);
            }
        }


        if (qType == 'SimpleQuestion' || qType == 'SimplePicturedQuestion') {
            questionOptionDiscriminator = 'SimpleQuestionOption';
        }
        else if (qType == "PictureQuestion") {
            questionOptionDiscriminator = 'PictureQuestionOption';
        }
        else if (qType == "EmojiQuestion") {
            questionOptionDiscriminator = 'EmojiQuestionOption';
        }


        for (let o = 0; o < optionContainers.length; o++) {

            let oContainer = optionContainers[o];

            let option = getQuestionOptionObj(qType, oContainer, questionOptionDiscriminator, formData);       
            question.Options.push(option);
        }


        questions.push(question);
    }


    formData.append('questions', JSON.stringify(questions));
    formData.append('questionIdsToDelete', JSON.stringify(questionIdsToDelete));
    formData.append('optionIdsToDelete', JSON.stringify(optionIdsToDelete));
    formData.append('testId', testId);

    await fetch(document.location.origin + '/SaveTestQuestions', {
        method: 'POST',
        body: formData
    });
}

function getQuestionOptionObj(qType,oContainer, questionOptionDiscriminator, formData) {

    let option = {
        Id: 0,
        Score: 0,
        Discriminator: questionOptionDiscriminator,
        FilesFromFrontend: 0,
        Text: '',
        Emoji: '',
        ImgPath: '',
    }

    if (oContainer.hasAttribute('data-id')) {
        option.Id = new Number(oContainer.getAttribute('data-id'));
    }

    console.log(oContainer);
    
    option.Score = new Number(oContainer.querySelector('[data-value="OptionScore"]').value);
    if (qType == 'SimpleQuestion'
        || qType == 'SimplePicturedQuestion'
        || qType == 'EmojiQuestion') {
        option.Text = oContainer.querySelector('[data-value="OptionText"]').value;

        if (qType == 'EmojiQuestion') {
            option.Emoji = oContainer.querySelector('[data-value="OptionEmoji"]').value;

        }
    }
    else if (qType == 'PictureQuestion') {
        let optionImage = oContainer.querySelector('[data-value="OptionImage"]');

        if (optionImage.hasAttribute('data-imgPath')) {
            option.ImgPath = optionImage.getAttribute('data-imgPath');        
        }

        option.FilesFromFrontend = optionImage.files.length;

        if (option.FilesFromFrontend > 0) {
            formData.append(`file_${filesCounter++}`, optionImage.files[0]);
        }
    }


    return option;
}









let resultIdsToDelete = [];


function createResult() {
    var elementhtml = `<div data-type="Result" class="page questions result-${VcreateResult}" id="result_${VcreateResult}">
                            <span class="removeresult"><i class="fa-sharp fa-solid fa-trash"></i></span>
                            <div class="row">
                                <div class="col-md-12">
                                    <ul class="nav nav-pills nav-fill mb-3" id="condition_selection_${VcreateResult}" role="tablist">
                                        <li class="nav-item" role="presentation">
                                            <button class="flex-sm-fill text-sm-center nav-link" id="pills-number${VcreateResult}-tab" onclick="setEqualCondition(${VcreateResult})" type="button">Ровно</button>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <button class="flex-sm-fill text-sm-center nav-link" id="pills-fromto${VcreateResult}-tab" onclick="setBetweenCondition(${VcreateResult})" type="button">От и до</button>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <button class="flex-sm-fill text-sm-center nav-link" id="pills-to${VcreateResult}-tab" onclick="setToCondition(${VcreateResult})" type="button">До</button>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <button class="flex-sm-fill text-sm-center nav-link" id="pills-next${VcreateResult}-tab" onclick="setFromCondition(${VcreateResult})" type="button">После</button>
                                        </li>
                                    </ul>

                                    <div class="tab-content margin-content" id="condition_container_${VcreateResult}">
                                       

                                                                            
                                    </div>
                                </div>

                                <div class="col-md-12">        
                                    <div class="mb-3">
                                        <label for="" class="formlabel">Заголовок</label>
                                        <input data-value="ResultTitle" type="text" class="form-control" placeholder="Введите заголовок">
                                    </div>

                                    <div class="mb-3">
                                        <label for="" class="formlabel">Текст</label>
                                        <textarea data-value="ResultText" class="form-control" rows="3" placeholder="Введите текст"></textarea>
                                    </div>

                                    <div class="mb-3">
                                        <div class="form-check">
                                            <input data-value="ResultNegative" class="form-check-input" type="checkbox">
                                            <label class="form-check-label label-transform">
                                               Негативный результат
                                            </label>
                                        </div>
                                    </div>     

                                </div>

                                <div class="col-md-12">
                                   <div class="tab-pane fade show active" id="pills-photo${VcreateResult}" role="tabpanel" aria-labelledby="pills-photo${VcreateResult}-tab" tabindex="0">
                                        <div class="mb-3">
                                            <label for="" class="formlabel">Изображение</label>
                                            <input data-value="ResultImg" type="file" class="form-control" id="uploadphoto${VcreateResult}">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>`;
    $('.qcontent').append(elementhtml);
    VcreateResult++;
}

function setEqualCondition(id) {
    let html = ` <div class="" id="pills-number${VcreateResult}">
                    <label for="" class="formlabel">Равно кол-ву баллов</label>
                    <input data-value="FirstValue" type="text" class="form-control" placeholder="Введите кол-во баллов">
                </div>`;
    $(`#condition_container_${id}`).append(html);
    $(`#condition_selection_${id}`).remove();
    $(`#result_${id}`).attr('data-condition-type','EQUAL');
}

function setBetweenCondition(id) {
    let html = `<div class="" id="pills-fromto${VcreateResult}">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="" class="formlabel">Баллов от</label>
                                <input data-value="FirstValue" type="text" class="form-control" placeholder="От">
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="" class="formlabel">до</label>
                                <input data-value="SecondValue" type="text" class="form-control" placeholder="До">
                            </div>
                        </div>
                    </div>
                </div>`;
    $(`#condition_container_${id}`).append(html);
    $(`#condition_selection_${id}`).remove();
    $(`#result_${id}`).attr('data-condition-type', 'BETWEEN');
}

function setToCondition(id) {
    let html = ` <div class="" id="pills-to${VcreateResult}">
                    <label for="" class="formlabel">Баллов до</label>
                    <input data-value="FirstValue" type="text" class="form-control" placeholder="До">
                </div>`;
    $(`#condition_container_${id}`).append(html);
    $(`#condition_selection_${id}`).remove();
    $(`#result_${id}`).attr('data-condition-type', 'TO');
}

function setFromCondition(id) {
    let html = ` <div class="" id="pills-to${VcreateResult}">
                    <label for="" class="formlabel">До кол-ва баллов</label>
                    <input data-value="FirstValue" type="text" class="form-control" placeholder="После">
                </div>`;
    $(`#condition_container_${id}`).append(html);
    $(`#condition_selection_${id}`).remove();
    $(`#result_${id}`).attr('data-condition-type', 'FROM');
}


function loadResult(result) {
    var elementhtml = `<div data-id="${result.id}" data-type="Result" class="page questions result-${VcreateResult}" id="result_${VcreateResult}">
                            <span class="removeresult" onclick="pushResultIdToDelete(${result.id})"><i class="fa-sharp fa-solid fa-trash"></i></span>
                            <div class="row">
                                <div class="col-md-12">
                                    <ul class="nav nav-pills nav-fill mb-3" id="condition_selection_${VcreateResult}" role="tablist">
                                      
                                    </ul>

                                    <div class="tab-content margin-content" id="condition_container_${VcreateResult}">
                                       

                                                                            
                                    </div>
                                </div>

                                <div class="col-md-12">        
                                    <div class="mb-3">
                                        <label for="" class="formlabel">Заголовок</label>
                                        <input data-value="ResultTitle" type="text" value="${result.title}" class="form-control" placeholder="Введите заголовок">
                                    </div>

                                    <div class="mb-3">
                                        <label for="" class="formlabel">Текст</label>
                                        <textarea data-value="ResultText" class="form-control" rows="3" placeholder="Введите текст">${result.text}</textarea>
                                    </div>

                                    <div class="mb-3">
                                        <div class="form-check">
                                            <input data-value="ResultNegative" class="form-check-input" type="checkbox">
                                            <label class="form-check-label label-transform">
                                               Негативный результат
                                            </label>
                                        </div>
                                    </div>    

                                </div>

                                <div class="col-md-12">
                                   <div class="tab-pane fade show active" id="pills-photo${VcreateResult}" role="tabpanel" aria-labelledby="pills-photo${VcreateResult}-tab" tabindex="0">
                                        <div class="mb-3">
                                            <label for="" class="formlabel">Изображение</label>
                                            <input data-value="ResultImg" data-imgPath="${result.imgPath}" type="file" class="form-control" id="uploadphoto${VcreateResult}">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>`;
    $('.qcontent').append(elementhtml);

    document.getElementById(`result_${VcreateResult}`).querySelector('[data-value="ResultNegative"]').checked = result.isNegativeResult;


    if (result.conditionType == 1) { //Equal
        loadEqualCondition(VcreateResult, result);
    }
    else if (result.conditionType == 2) { //Between
        loadBetweenCondition(VcreateResult, result);
    }
    else if (result.conditionType == 3) { //From
        loadFromCondition(VcreateResult, result);
    }
    else if (result.conditionType == 4) { //To
        loadToCondition(VcreateResult, result);
    }

    VcreateResult++;
}

function loadEqualCondition(id, result) {
    let html = ` <div class="" id="pills-number${VcreateResult}">
                    <label for="" class="formlabel">Равно кол-ву баллов</label>
                    <input data-value="FirstValue" value="${result.firstValue}" type="text" class="form-control" placeholder="Введите кол-во баллов">
                </div>`;
    $(`#condition_container_${id}`).append(html);
    $(`#condition_selection_${id}`).remove();
    $(`#result_${id}`).attr('data-condition-type', 'EQUAL');
}

function loadBetweenCondition(id, result) {
    let html = `<div class="" id="pills-fromto${VcreateResult}">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="" class="formlabel">Баллов от</label>
                                <input data-value="FirstValue" value="${result.firstValue}" type="text" class="form-control" placeholder="От">
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="" class="formlabel">до</label>
                                <input data-value="SecondValue" value="${result.secondValue}" type="text" class="form-control" placeholder="До">
                            </div>
                        </div>
                    </div>
                </div>`;
    $(`#condition_container_${id}`).append(html);
    $(`#condition_selection_${id}`).remove();
    $(`#result_${id}`).attr('data-condition-type', 'BETWEEN');
}

function loadToCondition(id, result) {
    let html = ` <div class="" id="pills-to${VcreateResult}">
                    <label for="" class="formlabel">Баллов до</label>
                    <input data-value="FirstValue" value="${result.firstValue}" type="text" class="form-control" placeholder="До">
                </div>`;
    $(`#condition_container_${id}`).append(html);
    $(`#condition_selection_${id}`).remove();
    $(`#result_${id}`).attr('data-condition-type', 'TO');
}

function loadFromCondition(id, result) {
    let html = ` <div class="" id="pills-to${VcreateResult}">
                    <label for="" class="formlabel">До кол-ва баллов</label>
                    <input data-value="FirstValue" type="text" value="${result.firstValue}" class="form-control" placeholder="После">
                </div>`;
    $(`#condition_container_${id}`).append(html);
    $(`#condition_selection_${id}`).remove();
    $(`#result_${id}`).attr('data-condition-type', 'FROM');
}



function pushResultIdToDelete(id) {
    resultIdsToDelete.push(new Number(id));
}


async function loadResults(id) {
    await fetch(document.location.origin + `/GetTestResults?id=${id}`)
        .then((response) => {
            return response.json();
        })
        .then((data) => {

            console.log(data);
            for (let i = 0; i < data.length; i++) {

                let result = data[i];
                loadResult(result);

            }
        });
}

async function saveResults(id) {

    let results = [];
    let formData = new FormData();
    filesCounter = 0;

    let resultContainers = document.querySelectorAll("[data-type='Result']");
    for (let i = 0; i < resultContainers.length; i++) {
        
        let result = {
            Id: 0,
            Title: '',
            Text: '',
            ImgPath: '',
            VideoPath: '',
            IsNegativeResult : false,
            FirstValue: 0,
            SecondValue: 0,
            ConditionType: 0,
            FilesFromFrontend: 0,
            NeedToHandleItemsIds : [],
        };
        

        let resultContainer = resultContainers[i];

        if (resultContainer.hasAttribute('data-id')) {
            result.Id = new Number(resultContainer.getAttribute('data-id'));
        }

        result.Title = resultContainer.querySelector("[data-value='ResultTitle']").value;
        result.Text = resultContainer.querySelector("[data-value='ResultText']").value;
        result.IsNegativeResult = resultContainer.querySelector("[data-value='ResultNegative']").checked;
        

        var imgFile = resultContainer.querySelector("[data-value='ResultImg']");
        if (imgFile.hasAttribute('data-imgPath')) {
            result.ImgPath = imgFile.getAttribute('data-imgPath');
        }

        result.FilesFromFrontend = imgFile.files.length;
        if (result.FilesFromFrontend > 0) {
            formData.append(`file_${filesCounter++}`, imgFile.files[0]);
        }

        //let selectedNeedToHandleOptions = resultContainer.querySelector("[data-value='needhandle-ids']").selectedOptions;


        //for (let selId = 0; selId < selectedNeedToHandleOptions.length; selId++) {
        //    let selIdOption = selectedNeedToHandleOptions[selId];

        //    result.NeedToHandleItemsIds.push(new Number(selIdOption.getAttribute('value')));
        //}


        let type = resultContainer.getAttribute('data-condition-type');
        if (type == 'EQUAL') {
            result.ConditionType = 1;
            result.FirstValue = new Number(resultContainer.querySelector("[data-value='FirstValue']").value);
        }
        else if (type == 'BETWEEN') {
            result.ConditionType = 2;
            result.FirstValue = new Number(resultContainer.querySelector("[data-value='FirstValue']").value);
            result.SecondValue = new Number(resultContainer.querySelector("[data-value='SecondValue']").value);
        }
        else if (type == 'FROM') {
            result.ConditionType = 3;
            result.FirstValue = new Number(resultContainer.querySelector("[data-value='FirstValue']").value);
        }
        else if (type == 'TO') {
            result.ConditionType = 4;
            result.FirstValue = new Number(resultContainer.querySelector("[data-value='FirstValue']").value);
        }

        results.push(result);
    }

    formData.append('results', JSON.stringify(results));
    formData.append('resultIdsToDelete', JSON.stringify(resultIdsToDelete));

    formData.append('testId', id);

    await fetch(document.location.origin + '/SaveTestResultsPage', {
        method: 'POST',
        body: formData
    });

}


async function getNeedToHandleItems() {
    await fetch(document.location.origin + `/GetNeedToHandleItems`)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            needToHandleItems = data;
            console.log(needToHandleItems);
        });
}
getNeedToHandleItems();


function getNeedToHandleSelectedItemsHtml(selectedIds) {
    let html = `<select class="form-select mb-2" data-value='needhandle-ids' multiple aria-label="multiple select example"> \r\n`;

    for (let i = 0; i < needToHandleItems.length; i++) {
        let item = needToHandleItems[i];

        let hasId = false;
        for (let j = 0; j < selectedIds.length; j++) {

            let selectedId = selectedIds[i];
            if (item.id == selectedId.id) {
                hasId = true;
                break;
            }
        }

        if (hasId == true) {
            html += `<option value="${item.id}" selected>${item.title}</option> \r\n`;
        }
        else {
            html += `<option value="${item.id}">${item.title}</option> \r\n`;
        }
    }

    html += `</select> \r\n`;
    return html;
}



