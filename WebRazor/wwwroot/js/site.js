// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



document.querySelectorAll('#sidebar .nav-link').forEach(link => {
        link.addEventListener('click', function () {

            // Remove active from all links
            document.querySelectorAll('#sidebar .nav-link').forEach(item => {
                item.classList.remove('active');
            });

            // Add active to clicked link
            this.classList.add('active');
        });
});

//populateCourts();

function draftSuccessfullySaved() {
    $('#draftSavedSuccessfully').modal('show');
}  

function retrieveDraft() {
    $('#draftFound').modal('show');
}

function showAlreadyExists() {
    $('#alreadyExists').modal('show');
}

//function populateCourts(courtName) {
//    const culture = document.getElementById("currentCulture").value;
//    let court = document.getElementById("courtCode").value;
//    let select = document.getElementById("txtCOURT");
//    if (select == null) {
//        select = document.getElementById("txtCOURTReview");
//    }
//    if (select == null) {
//        select = document.getElementById("txtCOURTResult");
//    }

//    var courtModel = {
//        "appId": "CAACS",
//        "region": "NEWRECORD",
//        "table": "CCM_MASTER",
//        "field": "COURT"

//    }

//    $.ajax({
//        url: $("#apiUrlPickCourt").val(),
//        type: 'POST',
//        data: JSON.stringify(courtModel), // convert to JSON
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',
//        success: function (response) {
//            console.log(response);
//            response.forEach(item => {
//                const option = document.createElement("option");
//                option.value = item.code;
//                if (culture.startsWith("fr")) {
//                    option.text = item.desc_fr_CA;
//                }
//                else {
//                    option.text = item.desc_en_CA;
//                }   
//                select.add(option); // or select.appendChild(option)
//                if (option.value == court) {
//                    option.selected = true;
//                }
//            });
//        },
//        error: function (err) {
//            console.error(err);
//            //$('#draftFound').modal('hide');
//            //$('#draftDeleteFailed').modal('show');
//            //alert("The draft save failed");
//        }
//    });
   
//}

if ($("#txtCOURTReview") != null) {
    $("#txtCOURTReview").each(function () {
        let original = $(this).val();
        $(this).on('change', function () {
            $(this).val(original);
        });
    });
}

if ($("#intREPORTINGYEARReview") != null) {
    $("#intREPORTINGYEARReview").each(function () {
        let original = $(this).val();
        $(this).on('change', function () {
            $(this).val(original);
        });
    });
}

if ($("#txtCOURTResult") != null) {
    $("#txtCOURTResult").each(function () {
        let original = $(this).val();
        $(this).on('change', function () {
            $(this).val(original);
        });
    });
}

if ($("#intREPORTINGYEARResult") != null) {
    $("#intREPORTINGYEARResult").each(function () {
        let original = $(this).val();
        $(this).on('change', function () {
            $(this).val(original);
        });
    });
}

//if (needRetrieve != null) {
//    retrieveDraft();
//}

function submitForm(sectionId) {
    var form = document.getElementById("reviewForm");
    form.action = "/Review?sectionId=" + sectionId;
    form.method = "POST";
    form.submit();
}

function submitForReview(cultureInfo) {
    var validator = $("form").validate();
    if ($('form').valid()) {
        if (!(validate(cultureInfo))) {
            $('#validationModal').modal('show');
            window.scrollTo({
                top: 0,
                behavior: "smooth"
            });
            return;
        }
        else {
            var form = document.getElementById("createForm");
            form.action = "/Review";
            form.submit();
        }
    }
    else {
        var errors = validator.errorList;
        showValidationSummary(errors);
    }
}

function finalSubmit() {
    if (validateFields("reviewForm")) {
        var form = document.getElementById("reviewForm");
        form.action = "/FinalMessage?finalSubmit=true";
        form.method = "post";
        form.submit();
    } else {
        window.scrollTo({
            top: 0,
            behavior: "smooth"
        }); 
    }
}

function submitForResult() {
    var form = document.getElementById("finalForm");
    form.action = "/Result";
    form.method = "post";
    form.submit();
}

function submitForSave() {
    if (validateFields("createForm")) {
        var form = document.getElementById("createForm");
        form.action = "/Create/Create?submitForSave=true";
        form.method = "post";
        form.submit();
    } else {
        window.scrollTo({
            top: 0,
            behavior: "smooth"
        }); 
    }
}

function submitStats() {
   
        var form = document.getElementById("selectForm");
        form.action = "/Create/Create?fromSelect=true&retrieveRecord=true";
        form.method = "post";
        form.submit();
    
}

function focusOnFormFromCreate(sectionId) {
    //let sectField = document.getElementById("sectionId");
    if (sectionId != null) {
        let sectId = sectionId;
        if (sectId != null && sectId != "") {
            $('#sidebarMessage').attr("hidden", true);
            setTabsBackgroundToInit();
            hideDetails("detailsBasicInfo");
            fieldFocus(sectId);
            //$("#btnReview").removeAttr("hidden");
            //$("#revMessage").removeAttr("hidden");
            $("#tabsbar").removeAttr("hidden");
            //enableDisableReview();
            //$("#btnReview").removeAttr('disabled');
            if (sectId != 12) {
                $("#btnNext").removeAttr("hidden");
            }
            else {
                $("#btnNext").attr("hidden", true);
            }
            if (sectId != 0) {
                $("#btnPrevious").removeAttr("hidden");
            }
            else {
                $("#btnPrevious").attr("hidden", true);
            }
        }
        else {
            $('#sidebarMessage').delay(5000).fadeOut(400);
        }
    }
}

function focusOnForm(sectionId) {
    if (sectionId != null && sectionId != "") {
        let sectField = document.getElementById("sectionId");
        if (sectField != null) {
            let sectId = sectField.value;
            if (sectId != null && sectId != "") {
                sectField.value = sectId;
                $('#sidebarMessage').attr("hidden", true);
                setTabsBackgroundToInit();
                hideDetails("detailsBasicInfo");
                fieldFocus(sectId);
                $("#btnReview").removeAttr("hidden");
                $("#revMessage").removeAttr("hidden");
                $("#tabsbar").removeAttr("hidden");
                //enableDisableReview();
                $("#btnReview").removeAttr('disabled');
                if (sectId != 12) {
                    $("#btnNext").removeAttr("hidden");
                }
                else {
                    $("#btnNext").attr("hidden", true);
                }
                if (sectId != 0) {
                    $("#btnPrevious").removeAttr("hidden");
                }
                else {
                    $("#btnPrevious").attr("hidden", true);
                }
            }
            else {
                $('#sidebarMessage').delay(5000).fadeOut(400);
            }
        }
    }
}

function fieldFocus(sectionId) {
    $("#lidetailsBasicInfo").removeClass("active");
    switch (sectionId) {
        case "1":
            $("#lidetails1").addClass("active");
            $("#activeDetailsId").val("details1");
            $('#details1').removeAttr('hidden');
            document.getElementById("txtFIELD1_1_1").focus();
            document.getElementById("txtFIELD1_1_1").setAttribute("required", "true");
            makeSection1Required();
            break;
        case "2":
            $("#lidetails2").addClass("active");
            $("#activeDetailsId").val("details2");
            $('#details2').removeAttr('hidden');
            document.getElementById("txtFIELD2_1_1").focus();
            makeSection2Required();
            break;
        case "3":
            $("#lidetails3").addClass("active");
            $("#activeDetailsId").val("details3");
            $('#details3').removeAttr('hidden');
            document.getElementById("txtFIELD3_1").focus();
            makeSection3Required();
            break;
        case "4":
            $("#lidetails4").addClass("active");
            $("#activeDetailsId").val("details4");
            $('#details4').removeAttr('hidden');
            document.getElementById("txtFIELD4_1_1").focus();
            makeSection4Required();
            break;
        case "5":
            $("#lidetails5").addClass("active");
            $("#activeDetailsId").val("details5");
            $('#details5').removeAttr('hidden');
            document.getElementById("txtFIELD5_1").focus();
            makeSection5Required();
            break;
        case "6":
            $("#lidetails6").addClass("active");
            $("#activeDetailsId").val("details6");
            $('#details6').removeAttr('hidden');
            document.getElementById("txtFIELD6_1_1").focus();
            makeSection6Required();
            break;
        case "7":
            $("#lidetails7").addClass("active");
            $("#activeDetailsId").val("details7");
            $('#details7').removeAttr('hidden');
            document.getElementById("txtFIELD7_1_1").focus();
            makeSection7Required();
            break;
        case "8":
            $("#lidetails8").addClass("active");
            $("#activeDetailsId").val("details8");
            $('#details8').removeAttr('hidden');
            document.getElementById("txtFIELD8_1").focus();
            makeSection8Required();
            break;
        case "9":
            $("#lidetails9").addClass("active");
            $("#activeDetailsId").val("details9");
            $('#details9').removeAttr('hidden');
            document.getElementById("txtFIELD9_1").focus();
            makeSection9Required();
            break;
        case "10":
            $("#lidetails10").addClass("active");
            $("#activeDetailsId").val("details10");
            $('#details10').removeAttr('hidden');
            document.getElementById("txtFIELD10_1").focus();
            makeSection10Required();
            break;
        case "11":
            $("#lidetails11").addClass("active");
            $("#activeDetailsId").val("details11");
            $('#details11').removeAttr('hidden');
            document.getElementById("txtFIELD11_1").focus();
            makeSection11Required();
            break;
        case "12":
            $("#lidetails12").addClass("active");
            $("#activeDetailsId").val("details12");
            $('#details12').removeAttr('hidden');
            document.getElementById("txtFIELD_12_Comments").focus();
            break;
        case '0':
            $("#lidetailsBasicInfo").addClass("active");
            $("#activeDetailsId").val("detailsBasicInfo");
            $('#detailsBasicInfo').removeAttr('hidden');
            document.getElementById("txtCOURT").focus();
            break;
    }
}

function showDetails(detailsId) {
    let activeDetails = $("#activeDetailsId").val();
    hideDetails(activeDetails);
    $('#li' + detailsId).addClass("active");
    $('#' + detailsId).removeAttr('hidden');
    $("#activeDetailsId").val(detailsId);
    let errorL = document.getElementById("errorList");
    errorL.innerHTML = "";
    let summary = document.getElementById("validationSummary");
    summary.classList.add("d-none");
    let sectField = document.getElementById("sectionId");
    if (sectField != null) {
        let sectId = sectField.value;
        if (sectId == null || sectId == "") {
            $("#btnReview").attr("hidden", true);
            $("#revMessage").attr("hidden", true);
        }
    }
    switch (detailsId) {
        case "detailsBasicInfo":
            $("#btnPrevious").attr("hidden", true);
            $("#btnNext").removeAttr("hidden");
            $("#btnSave").attr("hidden", true);
            $("#btnReview").attr("hidden", true);
            $("#revMessage").attr("hidden", true);
            $("#dtFROM").attr("readonly", true);
            $("#dtTO").attr("readonly", true);
            sectField.value = "0";
            break;
        case "details1":
            $("#btnPrevious").removeAttr("hidden");
            $("#btnNext").removeAttr("hidden");
            $("#btnSave").removeAttr("hidden");
            $("#btnReview").attr("hidden", true);
            $("#revMessage").attr("hidden", true);
            makeSection1Required();
            sectField.value = "1";
            break;
        case "details2":
            $("#btnPrevious").removeAttr("hidden");
            $("#btnNext").removeAttr("hidden");
            $("#btnSave").removeAttr("hidden");
            $("#btnReview").attr("hidden", true);
            $("#revMessage").attr("hidden", true);
            makeSection2Required();
            sectField.value = "2";
            break;
        case "details3":
            $("#btnPrevious").removeAttr("hidden");
            $("#btnNext").removeAttr("hidden");
            $("#btnSave").removeAttr("hidden");
            $("#btnReview").attr("hidden", true);
            $("#revMessage").attr("hidden", true);
            makeSection3Required();
            sectField.value = "3";
            break;
        case "details4":
            $("#btnPrevious").removeAttr("hidden");
            $("#btnNext").removeAttr("hidden");
            $("#btnSave").removeAttr("hidden");
            $("#btnReview").attr("hidden", true);
            $("#revMessage").attr("hidden", true);
            makeSection4Required();
            sectField.value = "4";
            break;
        case "details5":
            $("#btnPrevious").removeAttr("hidden");
            $("#btnNext").removeAttr("hidden");
            $("#btnSave").removeAttr("hidden");
            $("#btnReview").attr("hidden", true);
            $("#revMessage").attr("hidden", true);
            makeSection5Required();
            sectField.value = "5";
            break;
        case "details6":
            $("#btnPrevious").removeAttr("hidden");
            $("#btnNext").removeAttr("hidden");
            $("#btnSave").removeAttr("hidden");
            $("#btnReview").attr("hidden", true);
            $("#revMessage").attr("hidden", true);
            makeSection6Required();
            sectField.value = "6";
            break;
        case "details7":
            $("#btnPrevious").removeAttr("hidden");
            $("#btnNext").removeAttr("hidden");
            $("#btnSave").removeAttr("hidden");
            $("#btnReview").attr("hidden", true);
            $("#revMessage").attr("hidden", true);
            makeSection7Required();
            sectField.value = "7";
            break;
        case "details8":
            $("#btnPrevious").removeAttr("hidden");
            $("#btnNext").removeAttr("hidden");
            $("#btnSave").removeAttr("hidden");
            $("#btnReview").attr("hidden", true);
            $("#revMessage").attr("hidden", true);
            makeSection8Required();
            sectField.value = "8";
            break;
        case "details9":
            $("#btnPrevious").removeAttr("hidden");
            $("#btnNext").removeAttr("hidden");
            $("#btnSave").removeAttr("hidden");
            $("#btnReview").attr("hidden", true);
            $("#revMessage").attr("hidden", true);
            makeSection9Required();
            sectField.value = "9";
            break;
        case "details10":
            $("#btnPrevious").removeAttr("hidden");
            $("#btnNext").removeAttr("hidden");
            $("#btnSave").removeAttr("hidden");
            $("#btnReview").attr("hidden", true);
            $("#revMessage").attr("hidden", true);
            makeSection10Required();
            sectField.value = "10";
            break;
        case "details11":
            $("#btnPrevious").removeAttr("hidden");
            $("#btnNext").removeAttr("hidden");
            $("#btnSave").removeAttr("hidden");
            $("#btnReview").attr("hidden", true);
            $("#revMessage").attr("hidden", true);
            makeSection11Required();
            sectField.value = "11";
            break;
        case "details12":
            $("#btnReview").removeAttr("hidden");
            $("#revMessage").removeAttr("hidden", true);
            $("#btnPrevious").removeAttr("hidden");
            $("#btnNext").attr("hidden", true);
            $("#btnSave").attr("hidden", true);
            sectField.value = "12";
            break;
    }
}

function hideDetails(detailsId) {
    //$('#li' + detailsId).css("background", "#26374A");
    $('#' + detailsId).attr('hidden', true);
    switch (detailsId) {
        case "detailsBasicInfo":
            $("#dtFROM").attr("readonly", true);
            $("#dtTO").attr("readonly", true);
            break;
        case "details1":
            makeSection1NotRequired();
            break;
        case "details2":
            makeSection2NotRequired();
            break;
        case "details3":
            makeSection3NotRequired();
            break;
        case "details4":
            makeSection4NotRequired();
            break;
        case "details5":
            makeSection5NotRequired();
            break;
        case "details6":
            makeSection6NotRequired();
            break;
        case "details7":
            makeSection7NotRequired();
            break;
        case "details8":
            makeSection8NotRequired();
            break;
        case "details9":
            makeSection9NotRequired();
            break;
        case "details10":
            makeSection10NotRequired();
            break;
        case "details11":
            makeSection11NotRequired();
            break;
        case "details12":
            break;
    }
}

function gotoPrevious() {
    let activeDetails = $("#activeDetailsId").val();
    switch (activeDetails) {
        case "detailsBasicInfo":
            $("#dtFROM").attr("readonly", true);
            $("#dtTO").attr("readonly", true);
            break;
        case "details1":
            $("#btnPrevious").attr("hidden", true);
            $("#btnNext").removeAttr("hidden");
            showDetails("detailsBasicInfo");
            $("#lidetailsBasicInfo").addClass("active");
            $("#lidetails1").removeClass("active");
            makeSection1NotRequired();
            $("#btnSave").removeAttr('hidden');
            break;
        case "details2": showDetails("details1");
            $("#lidetails1").addClass("active");
            $("#lidetails2").removeClass("active");
            makeSection2NotRequired();
            $("#btnSave").removeAttr('hidden');
            break;
        case "details3": showDetails("details2");
            $("#lidetails2").addClass("active");
            $("#lidetails3").removeClass("active");
            makeSection3NotRequired();
            $("#btnSave").removeAttr('hidden');
            break;
        case "details4": showDetails("details3");
            $("#lidetails3").addClass("active");
            $("#lidetails4").removeClass("active");
            makeSection4NotRequired();
            $("#btnSave").removeAttr('hidden');
            break;
        case "details5": showDetails("details4");
            $("#lidetails4").addClass("active");
            $("#lidetails5").removeClass("active");
            makeSection5NotRequired();
            $("#btnSave").removeAttr('hidden');
            break;
        case "details6": showDetails("details5");
            $("#lidetails5").addClass("active");
            $("#lidetails6").removeClass("active");
            makeSection6NotRequired();
            $("#btnSave").removeAttr('hidden');
            break;
        case "details7": showDetails("details6");
            $("#lidetails6").addClass("active");
            $("#lidetails7").removeClass("active");
            makeSection7NotRequired();
            $("#btnSave").removeAttr('hidden');
            break;
        case "details8": showDetails("details7");
            $("#lidetails7").addClass("active");
            $("#lidetails8").removeClass("active");
            makeSection8NotRequired();
            $("#btnSave").removeAttr('hidden');
            break;
        case "details9": showDetails("details8");
            $("#lidetails8").addClass("active");
            $("#lidetails9").removeClass("active");
            makeSection9NotRequired();
            $("#btnSave").removeAttr('hidden');
            break;
        case "details10": showDetails("details9");
            $("#lidetails9").addClass("active");
            $("#lidetails10").removeClass("active");
            makeSection10NotRequired();
            $("#btnSave").removeAttr('hidden');
            break;
        case "details11": showDetails("details10");
            $("#lidetails10").addClass("active");
            $("#lidetails11").removeClass("active");
            makeSection11NotRequired();
            $("#btnSave").removeAttr('hidden');
            break;
        case "details12":
            let sectField = document.getElementById("sectionId");
            if (sectField != null) {
                let sectId = sectField.value;
                if (sectId != null && sectId != "") {
                    $("#btnReview").removeAttr("hidden");
                    $("#revMessage").removeAttr("hidden");
                }
                else {
                    $("#btnReview").attr("hidden", true);
                    $("#revMessage").attr("hidden", true);
                }
            }
            $("#btnNext").removeAttr("hidden");
            showDetails("details11");
            $("#lidetails11").addClass("active");
            $("#lidetails12").removeClass("active");
            $("#btnSave").removeAttr('hidden');
            break;
    }
    const summary = document.getElementById("validationSummary");
    summary.classList.add("d-none");
    window.scrollTo({
        top: 0,
        behavior: "smooth"
    });
}

function gotoNext() {
    //var validator = $("form").validate();
    if (validateFields("createForm")) {
        //const summary = document.getElementById("validationSummary");
        //summary.classList.add("d-none");
        let activeDetails = $("#activeDetailsId").val();
        switch (activeDetails) {
            case "detailsBasicInfo":
                $("#btnPrevious").removeAttr("hidden");
                showDetails("details1");
                $("#lidetails1").addClass("active");
                $("#lidetailsBasicInfo").removeClass("active");
                makeSection1Required();
                $("#btnSave").removeAttr('hidden');
                break;
            case "details1": showDetails("details2");
                $("#lidetails2").addClass("active");
                $("#lidetails1").removeClass("active");
                makeSection2Required();
                $("#btnSave").removeAttr('hidden');
                break;
            case "details2": showDetails("details3");
                $("#lidetails3").addClass("active");
                $("#lidetails2").removeClass("active");
                makeSection3Required();
                $("#btnSave").removeAttr('hidden');
                break;
            case "details3": showDetails("details4");
                $("#lidetails4").addClass("active");
                $("#lidetails3").removeClass("active");
                makeSection4Required();
                $("#btnSave").removeAttr('hidden');
                break;
            case "details4": showDetails("details5");
                $("#lidetails5").addClass("active");
                $("#lidetails4").removeClass("active");
                makeSection5Required();
                $("#btnSave").removeAttr('hidden');
                break;
            case "details5": showDetails("details6");
                $("#lidetails6").addClass("active");
                $("#lidetails5").removeClass("active");
                makeSection6Required();
                $("#btnSave").removeAttr('hidden');
                break;
            case "details6": showDetails("details7");
                $("#lidetails7").addClass("active");
                $("#lidetails6").removeClass("active");
                makeSection7Required();
                $("#btnSave").removeAttr('hidden');
                break;
            case "details7": showDetails("details8");
                $("#lidetails8").addClass("active");
                $("#lidetails7").removeClass("active");
                makeSection8Required();
                $("#btnSave").removeAttr('hidden');
                break;
            case "details8": showDetails("details9");
                $("#lidetails9").addClass("active");
                $("#lidetails8").removeClass("active");
                makeSection9Required();
                $("#btnSave").removeAttr('hidden');
                break;
            case "details9": showDetails("details10");
                $("#lidetails10").addClass("active");
                $("#lidetails9").removeClass("active");
                makeSection10Required();
                $("#btnSave").removeAttr('hidden');
                break;
            case "details10": showDetails("details11");
                $("#lidetails11").addClass("active");
                $("#lidetails10").removeClass("active");
                makeSection11Required();
                $("#btnSave").removeAttr('hidden');
                break;
            case "details11": showDetails("details12");
                $("#lidetails12").addClass("active");
                $("#lidetails11").removeClass("active");
                $("#btnNext").attr("hidden", true);
                $("#btnReview").removeAttr("hidden");
                $("#btnPrevious").removeAttr("hidden");
                $("#revMessage").removeAttr("hidden");
                break;
            case "details12":
                break;
        }
    }
    else {
        //var errors = validator.errorList;
        //showValidationSummary(errors);
    }
    window.scrollTo({
        top: 0,
        behavior: "smooth"
    });
}

function enableDisableReview() {
    if ($("#txtCOURT").val() != ""
        && $("#intREPORTINGYEAR").val() != ""
        && $("#dtFROM").val() != ""
        && $("#dtTO").val() != ""
    ) {
        //if (!(retrieveExisting())) {
        $("#btnReview").removeAttr('disabled');
        $("#tabsbar").removeAttr('hidden');
        //}
        var form = document.getElementById("createForm");
        form.action = "/Create/Create?retrieveDraft=true";
        form.method = "post";
        form.submit();
    }
    else {
        $("#btnReview").attr('disabled', true);
    }
}


//document.getElementById("intREPORTINGYEAR").addEventListener("change", function () {
//    const year = this.value;
//    if (!year) return;

//    //document.getElementById("dtFROM").min = `${year}-01-01`;
//    document.getElementById("dtFROM").max = `${year}-12-31`;
//    document.getElementById("dtTO").min = `${year}-01-01`;
//    document.getElementById("dtTO").max = `${year}-12-31`;

//    document.getElementById("dtFROM").value = `${year}-01-01`;
//    document.getElementById("dtTO").value = `${year}-12-31`;

//    enableDisableReview();
//});

function setTabsBackgroundToInit() {
    $("#lidetailsBasicInfo").removeClass("active");
    $("#lidetails1").removeClass("active");
    $("#lidetails2").removeClass("active");
    $("#lidetails3").removeClass("active");
    $("#lidetails4").removeClass("active");
    $("#lidetails5").removeClass("active");
    $("#lidetails6").removeClass("active");
    $("#lidetails7").removeClass("active");
    $("#lidetails8").removeClass("active");
    $("#lidetails9").removeClass("active");
    $("#lidetails10").removeClass("active");
    $("#lidetails11").removeClass("active");
    $("#lidetails12").removeClass("active");
}

function submitBasicInfoForm() {
    var form = document.getElementById("basicInfoForm");
    form.action = "/Create?handler=basicinfo";
    form.method = "POST";
    form.submit();
}

function showValidationSummary(errors) {
    const summary = document.getElementById("validationSummary");
    const list = document.getElementById("errorList");
    list.innerHTML = ""; // Clear previous errors

    errors.forEach(error => {
        const li = document.createElement("li");
        li.textContent = error.message;
        list.appendChild(li);
    });

    summary.classList.remove("d-none");
}

// Make Required
function makeSection1Required() {
    document.getElementById("txtFIELD1_1_1").setAttribute("required", "true");
    document.getElementById("txtFIELD1_1_2").setAttribute("required", "true");
    document.getElementById("txtFIELD1_1_3").setAttribute("required", "true");
    document.getElementById("txtFIELD1_1_4").setAttribute("required", "true");
    document.getElementById("txtFIELD1_1_5").setAttribute("required", "true");
    document.getElementById("txtFIELD1_1_6").setAttribute("required", "true");
    document.getElementById("txtFIELD1_1_7").setAttribute("required", "true");
    document.getElementById("txtFIELD1_2_1").setAttribute("required", "true");
    document.getElementById("txtFIELD1_2_2").setAttribute("required", "true");
    document.getElementById("txtFIELD1_2_3").setAttribute("required", "true");
    document.getElementById("txtFIELD1_2_4").setAttribute("required", "true");
    document.getElementById("txtFIELD1_2_5").setAttribute("required", "true");
}

function makeSection2Required() {
    document.getElementById("txtFIELD2_1_1").setAttribute("required", "true");
    document.getElementById("txtFIELD2_1_2").setAttribute("required", "true");
    document.getElementById("txtFIELD2_2_1").setAttribute("required", "true");
    document.getElementById("txtFIELD2_2_1_1").setAttribute("required", "true");
    document.getElementById("txtFIELD2_2_1_2").setAttribute("required", "true");
    document.getElementById("txtFIELD2_2_1_3").setAttribute("required", "true");
    document.getElementById("txtFIELD2_2_2").setAttribute("required", "true");
    document.getElementById("txtFIELD2_2_2_1").setAttribute("required", "true");
    document.getElementById("txtFIELD2_2_2_2").setAttribute("required", "true");
    document.getElementById("txtFIELD2_2_2_3").setAttribute("required", "true");
}

function makeSection3Required() {
    document.getElementById("txtFIELD3_1").setAttribute("required", "true");
    document.getElementById("txtFIELD3_2").setAttribute("required", "true");
}

function makeSection4Required() {
    document.getElementById("txtFIELD4_1_1").setAttribute("required", "true");
    document.getElementById("txtFIELD4_1_2").setAttribute("required", "true");
    document.getElementById("txtFIELD4_1_3").setAttribute("required", "true");
    document.getElementById("txtFIELD4_1_4_1").setAttribute("required", "true");
    document.getElementById("txtFIELD4_1_4_2").setAttribute("required", "true");
    document.getElementById("txtFIELD4_1_4_3").setAttribute("required", "true");
    document.getElementById("txtFIELD4_1_5_1").setAttribute("required", "true");
    document.getElementById("txtFIELD4_1_5_2").setAttribute("required", "true");
    document.getElementById("txtFIELD4_1_5_3").setAttribute("required", "true");
    document.getElementById("txtFIELD4_1_6_1").setAttribute("required", "true");
    document.getElementById("txtFIELD4_1_6_2").setAttribute("required", "true");
    document.getElementById("txtFIELD4_1_6_3").setAttribute("required", "true");
    document.getElementById("txtFIELD4_2_1").setAttribute("required", "true");
    document.getElementById("txtFIELD4_2_2").setAttribute("required", "true");
    document.getElementById("txtFIELD4_2_3").setAttribute("required", "true");
    document.getElementById("txtFIELD4_2_4_1").setAttribute("required", "true");
    document.getElementById("txtFIELD4_2_4_2").setAttribute("required", "true");
    document.getElementById("txtFIELD4_2_4_3").setAttribute("required", "true");
    document.getElementById("txtFIELD4_2_5_1").setAttribute("required", "true");
    document.getElementById("txtFIELD4_2_5_2").setAttribute("required", "true");
    document.getElementById("txtFIELD4_2_5_3").setAttribute("required", "true");
    document.getElementById("txtFIELD4_2_6_1").setAttribute("required", "true");
    document.getElementById("txtFIELD4_2_6_2").setAttribute("required", "true");
    document.getElementById("txtFIELD4_2_6_3").setAttribute("required", "true");
    document.getElementById("txtFIELD4_3_1").setAttribute("required", "true");
    document.getElementById("txtFIELD4_3_2").setAttribute("required", "true");
    document.getElementById("txtFIELD4_3_3").setAttribute("required", "true");
    document.getElementById("txtFIELD4_3_4_1").setAttribute("required", "true");
    document.getElementById("txtFIELD4_3_4_2").setAttribute("required", "true");
    document.getElementById("txtFIELD4_3_4_3").setAttribute("required", "true");
    document.getElementById("txtFIELD4_3_5_1").setAttribute("required", "true");
    document.getElementById("txtFIELD4_3_5_2").setAttribute("required", "true");
    document.getElementById("txtFIELD4_3_5_3").setAttribute("required", "true");
    document.getElementById("txtFIELD4_3_6_1").setAttribute("required", "true");
    document.getElementById("txtFIELD4_3_6_2").setAttribute("required", "true");
    document.getElementById("txtFIELD4_3_6_3").setAttribute("required", "true");
}

function makeSection5Required() {
    document.getElementById("txtFIELD5_1").setAttribute("required", "true");
    document.getElementById("txtFIELD5_2").setAttribute("required", "true");
    document.getElementById("txtFIELD5_3").setAttribute("required", "true");
    document.getElementById("txtFIELD5_4").setAttribute("required", "true");
}

function makeSection6Required() {
    document.getElementById("txtFIELD6_1_1").setAttribute("required", "true");
    document.getElementById("txtFIELD6_1_2").setAttribute("required", "true");
    document.getElementById("txtFIELD6_1_3").setAttribute("required", "true");
    document.getElementById("txtFIELD6_2_1").setAttribute("required", "true");
    document.getElementById("txtFIELD6_2_2").setAttribute("required", "true");
    document.getElementById("txtFIELD6_2_3").setAttribute("required", "true");
    document.getElementById("txtFIELD6_3_1").setAttribute("required", "true");
    document.getElementById("txtFIELD6_3_2").setAttribute("required", "true");
    document.getElementById("txtFIELD6_3_3").setAttribute("required", "true");
}

function makeSection7Required() {
    document.getElementById("txtFIELD7_1_1").setAttribute("required", "true");
    document.getElementById("txtFIELD7_1_2").setAttribute("required", "true");
    document.getElementById("txtFIELD7_1_3").setAttribute("required", "true");
}

function makeSection8Required() {
    document.getElementById("txtFIELD8_1").setAttribute("required", "true");
    document.getElementById("txtFIELD8_2").setAttribute("required", "true");
    document.getElementById("txtFIELD8_3").setAttribute("required", "true");
}

function makeSection9Required() {
    document.getElementById("txtFIELD9_1").setAttribute("required", "true");
    document.getElementById("txtFIELD9_2").setAttribute("required", "true");
}

function makeSection10Required() {
    document.getElementById("txtFIELD10_1").setAttribute("required", "true");
}

function makeSection11Required() {
    document.getElementById("txtFIELD11_1").setAttribute("required", "true");
    document.getElementById("txtFIELD11_2").setAttribute("required", "true");
}

// Make Not Required
function makeSection1NotRequired() {
    document.getElementById("txtFIELD1_1_1").removeAttribute("required");
    document.getElementById("txtFIELD1_1_2").removeAttribute("required");
    document.getElementById("txtFIELD1_1_3").removeAttribute("required");
    document.getElementById("txtFIELD1_1_4").removeAttribute("required");
    document.getElementById("txtFIELD1_1_5").removeAttribute("required");
    document.getElementById("txtFIELD1_1_6").removeAttribute("required");
    document.getElementById("txtFIELD1_1_7").removeAttribute("required");
    document.getElementById("txtFIELD1_2_1").removeAttribute("required");
    document.getElementById("txtFIELD1_2_2").removeAttribute("required");
    document.getElementById("txtFIELD1_2_3").removeAttribute("required");
    document.getElementById("txtFIELD1_2_4").removeAttribute("required");
    document.getElementById("txtFIELD1_2_5").removeAttribute("required");
}

function makeSection2NotRequired() {
    document.getElementById("txtFIELD2_1_1").removeAttribute("required");
    document.getElementById("txtFIELD2_1_2").removeAttribute("required");
    document.getElementById("txtFIELD2_2_1").removeAttribute("required");
    document.getElementById("txtFIELD2_2_1_1").removeAttribute("required");
    document.getElementById("txtFIELD2_2_1_2").removeAttribute("required");
    document.getElementById("txtFIELD2_2_1_3").removeAttribute("required");
    document.getElementById("txtFIELD2_2_2").removeAttribute("required");
    document.getElementById("txtFIELD2_2_2_1").removeAttribute("required");
    document.getElementById("txtFIELD2_2_2_2").removeAttribute("required");
    document.getElementById("txtFIELD2_2_2_3").removeAttribute("required");
}

function makeSection3NotRequired() {
    document.getElementById("txtFIELD3_1").removeAttribute("required");
    document.getElementById("txtFIELD3_2").removeAttribute("required");
}

function makeSection4NotRequired() {
    document.getElementById("txtFIELD4_1_1").removeAttribute("required");
    document.getElementById("txtFIELD4_1_2").removeAttribute("required");
    document.getElementById("txtFIELD4_1_3").removeAttribute("required");
    document.getElementById("txtFIELD4_1_4_1").removeAttribute("required");
    document.getElementById("txtFIELD4_1_4_2").removeAttribute("required");
    document.getElementById("txtFIELD4_1_4_3").removeAttribute("required");
    document.getElementById("txtFIELD4_1_5_1").removeAttribute("required");
    document.getElementById("txtFIELD4_1_5_2").removeAttribute("required");
    document.getElementById("txtFIELD4_1_5_3").removeAttribute("required");
    document.getElementById("txtFIELD4_1_6_1").removeAttribute("required");
    document.getElementById("txtFIELD4_1_6_2").removeAttribute("required");
    document.getElementById("txtFIELD4_1_6_3").removeAttribute("required");
    document.getElementById("txtFIELD4_2_1").removeAttribute("required");
    document.getElementById("txtFIELD4_2_2").removeAttribute("required");
    document.getElementById("txtFIELD4_2_3").removeAttribute("required");
    document.getElementById("txtFIELD4_2_4_1").removeAttribute("required");
    document.getElementById("txtFIELD4_2_4_2").removeAttribute("required");
    document.getElementById("txtFIELD4_2_4_3").removeAttribute("required");
    document.getElementById("txtFIELD4_2_5_1").removeAttribute("required");
    document.getElementById("txtFIELD4_2_5_2").removeAttribute("required");
    document.getElementById("txtFIELD4_2_5_3").removeAttribute("required");
    document.getElementById("txtFIELD4_2_6_1").removeAttribute("required");
    document.getElementById("txtFIELD4_2_6_2").removeAttribute("required");
    document.getElementById("txtFIELD4_2_6_3").removeAttribute("required");
    document.getElementById("txtFIELD4_3_1").removeAttribute("required");
    document.getElementById("txtFIELD4_3_2").removeAttribute("required");
    document.getElementById("txtFIELD4_3_3").removeAttribute("required");
    document.getElementById("txtFIELD4_3_4_1").removeAttribute("required");
    document.getElementById("txtFIELD4_3_4_2").removeAttribute("required");
    document.getElementById("txtFIELD4_3_4_3").removeAttribute("required");
    document.getElementById("txtFIELD4_3_5_1").removeAttribute("required");
    document.getElementById("txtFIELD4_3_5_2").removeAttribute("required");
    document.getElementById("txtFIELD4_3_5_3").removeAttribute("required");
    document.getElementById("txtFIELD4_3_6_1").removeAttribute("required");
    document.getElementById("txtFIELD4_3_6_2").removeAttribute("required");
    document.getElementById("txtFIELD4_3_6_3").removeAttribute("required");
}

function makeSection5NotRequired() {
    document.getElementById("txtFIELD5_1").removeAttribute("required");
    document.getElementById("txtFIELD5_2").removeAttribute("required");
    document.getElementById("txtFIELD5_3").removeAttribute("required");
    document.getElementById("txtFIELD5_4").removeAttribute("required");
}

function makeSection6NotRequired() {
    document.getElementById("txtFIELD6_1_1").removeAttribute("required");
    document.getElementById("txtFIELD6_1_2").removeAttribute("required");
    document.getElementById("txtFIELD6_1_3").removeAttribute("required");
    document.getElementById("txtFIELD6_2_1").removeAttribute("required");
    document.getElementById("txtFIELD6_2_2").removeAttribute("required");
    document.getElementById("txtFIELD6_2_3").removeAttribute("required");
    document.getElementById("txtFIELD6_3_1").removeAttribute("required");
    document.getElementById("txtFIELD6_3_2").removeAttribute("required");
    document.getElementById("txtFIELD6_3_3").removeAttribute("required");
}

function makeSection7NotRequired() {
    document.getElementById("txtFIELD7_1_1").removeAttribute("required");
    document.getElementById("txtFIELD7_1_2").removeAttribute("required");
    document.getElementById("txtFIELD7_1_3").removeAttribute("required");
}

function makeSection8NotRequired() {
    document.getElementById("txtFIELD8_1").removeAttribute("required");
    document.getElementById("txtFIELD8_2").removeAttribute("required");
    document.getElementById("txtFIELD8_3").removeAttribute("required");
}

function makeSection9NotRequired() {
    document.getElementById("txtFIELD9_1").removeAttribute("required");
    document.getElementById("txtFIELD9_2").removeAttribute("required");
}

function makeSection10NotRequired() {
    document.getElementById("txtFIELD10_1").removeAttribute("required");
}

function makeSection11NotRequired() {
    document.getElementById("txtFIELD11_1").removeAttribute("required");
    document.getElementById("txtFIELD11_2").removeAttribute("required");
}

function calculateField_1_1_7() {
    let calcSum = 0;
    if (document.getElementById("txtFIELD1_1_1").value != "") {
        calcSum = calcSum + parseInt(document.getElementById("txtFIELD1_1_1").value);
    }
    if (document.getElementById("txtFIELD1_1_2").value != "") {
        calcSum = calcSum + parseInt(document.getElementById("txtFIELD1_1_2").value);
    }
    if (document.getElementById("txtFIELD1_1_3").value != "") {
        calcSum = calcSum - parseInt(document.getElementById("txtFIELD1_1_3").value);
    }
    if (document.getElementById("txtFIELD1_1_4").value != "") {
        calcSum = calcSum - parseInt(document.getElementById("txtFIELD1_1_4").value);
    }
    if (document.getElementById("txtFIELD1_1_5").value != "") {
        calcSum = calcSum - parseInt(document.getElementById("txtFIELD1_1_5").value);
    }
    if (document.getElementById("txtFIELD1_1_6").value != "") {
        calcSum = calcSum - parseInt(document.getElementById("txtFIELD1_1_6").value);
    }
    document.getElementById("txtFIELD1_1_7").value = calcSum;
}

function calculateField_1_2_5() {
    let calcSum = 0;
    if (document.getElementById("txtFIELD1_2_1").value != "") {
        calcSum = calcSum + parseInt(document.getElementById("txtFIELD1_2_1").value);
    }
    if (document.getElementById("txtFIELD1_2_2").value != "") {
        calcSum = calcSum + parseInt(document.getElementById("txtFIELD1_2_2").value);
    }
    if (document.getElementById("txtFIELD1_2_3").value != "") {
        calcSum = calcSum - parseInt(document.getElementById("txtFIELD1_2_3").value);
    }
    if (document.getElementById("txtFIELD1_2_4").value != "") {
        calcSum = calcSum - parseInt(document.getElementById("txtFIELD1_2_4").value);
    }
    document.getElementById("txtFIELD1_2_5").value = calcSum;
}

function calculateField_5_4() {
    let calcSum = 0;
    if (document.getElementById("txtFIELD5_1").value != "") {
        calcSum = calcSum + parseInt(document.getElementById("txtFIELD5_1").value);
    }
    if (document.getElementById("txtFIELD5_2").value != "") {
        calcSum = calcSum + parseInt(document.getElementById("txtFIELD5_2").value);
    }
    if (document.getElementById("txtFIELD5_3").value != "") {
        calcSum = calcSum + parseInt(document.getElementById("txtFIELD5_3").value);
    }
    document.getElementById("txtFIELD5_4").value = calcSum;
}

function calculateField_7_1_3() {
    let calcSum = 0;
    if (document.getElementById("txtFIELD7_1_1").value != "") {
        calcSum = calcSum + parseInt(document.getElementById("txtFIELD7_1_1").value);
    }
    if (document.getElementById("txtFIELD7_1_2").value != "") {
        calcSum = calcSum + parseInt(document.getElementById("txtFIELD7_1_2").value);
    }
    document.getElementById("txtFIELD7_1_3").value = calcSum;
}

function validate(cultureInfo) {

    let result = true;
    let errorHtml = "";

    let fIELD1_1_1 = document.getElementById("txtFIELD1_1_1");
    let fIELD1_1_2 = document.getElementById("txtFIELD1_1_2");
    let fIELD1_1_3 = document.getElementById("txtFIELD1_1_3");
    let fIELD1_1_4 = document.getElementById("txtFIELD1_1_4");
    let fIELD1_1_5 = document.getElementById("txtFIELD1_1_5");
    let fIELD1_1_6 = document.getElementById("txtFIELD1_1_6");
    let fIELD1_1_7 = document.getElementById("txtFIELD1_1_7");
    let fIELD1_2_1 = document.getElementById("txtFIELD1_2_1");
    let fIELD1_2_2 = document.getElementById("txtFIELD1_2_2");
    let fIELD1_2_3 = document.getElementById("txtFIELD1_2_3");
    let fIELD1_2_4 = document.getElementById("txtFIELD1_2_4");
    let fIELD1_2_5 = document.getElementById("txtFIELD1_2_5");

    let txtFIELD2_1_1 = document.getElementById("txtFIELD2_1_1");
    let txtFIELD2_1_2 = document.getElementById("txtFIELD2_1_2");
    let txtFIELD2_2_1 = document.getElementById("txtFIELD2_2_1");
    let txtFIELD2_2_1_1 = document.getElementById("txtFIELD2_2_1_1");
    let txtFIELD2_2_1_2 = document.getElementById("txtFIELD2_2_1_2");
    let txtFIELD2_2_1_3 = document.getElementById("txtFIELD2_2_1_3");
    let txtFIELD2_2_2 = document.getElementById("txtFIELD2_2_2");
    let txtFIELD2_2_2_1 = document.getElementById("txtFIELD2_2_2_1");
    let txtFIELD2_2_2_2 = document.getElementById("txtFIELD2_2_2_2");
    let txtFIELD2_2_2_3 = document.getElementById("txtFIELD2_2_2_3");

    let txtFIELD3_1 = document.getElementById("txtFIELD3_1");
    let txtFIELD3_2 = document.getElementById("txtFIELD3_2");

    let txtFIELD4_1_1 = document.getElementById("txtFIELD4_1_1");
    let txtFIELD4_1_2 = document.getElementById("txtFIELD4_1_2");
    let txtFIELD4_1_3 = document.getElementById("txtFIELD4_1_3");
    let txtFIELD4_1_4_1 = document.getElementById("txtFIELD4_1_4_1");
    let txtFIELD4_1_4_2 = document.getElementById("txtFIELD4_1_4_2");
    let txtFIELD4_1_4_3 = document.getElementById("txtFIELD4_1_4_3");
    let txtFIELD4_1_5_1 = document.getElementById("txtFIELD4_1_5_1");
    let txtFIELD4_1_5_2 = document.getElementById("txtFIELD4_1_5_2");
    let txtFIELD4_1_5_3 = document.getElementById("txtFIELD4_1_5_3");
    let txtFIELD4_1_6_1 = document.getElementById("txtFIELD4_1_6_1");
    let txtFIELD4_1_6_2 = document.getElementById("txtFIELD4_1_6_2");
    let txtFIELD4_1_6_3 = document.getElementById("txtFIELD4_1_6_3");
    let txtFIELD4_2_1 = document.getElementById("txtFIELD4_2_1");
    let txtFIELD4_2_2 = document.getElementById("txtFIELD4_2_2");
    let txtFIELD4_2_3 = document.getElementById("txtFIELD4_2_3");
    let txtFIELD4_2_4_1 = document.getElementById("txtFIELD4_2_4_1");
    let txtFIELD4_2_4_2 = document.getElementById("txtFIELD4_2_4_2");
    let txtFIELD4_2_4_3 = document.getElementById("txtFIELD4_2_4_3");
    let txtFIELD4_2_5_1 = document.getElementById("txtFIELD4_2_5_1");
    let txtFIELD4_2_5_2 = document.getElementById("txtFIELD4_2_5_2");
    let txtFIELD4_2_5_3 = document.getElementById("txtFIELD4_2_5_3");
    let txtFIELD4_2_6_1 = document.getElementById("txtFIELD4_2_6_1");
    let txtFIELD4_2_6_2 = document.getElementById("txtFIELD4_2_6_2");
    let txtFIELD4_2_6_3 = document.getElementById("txtFIELD4_2_6_3");
    let txtFIELD4_3_1 = document.getElementById("txtFIELD4_3_1");
    let txtFIELD4_3_2 = document.getElementById("txtFIELD4_3_2");
    let txtFIELD4_3_3 = document.getElementById("txtFIELD4_3_3");
    let txtFIELD4_3_4_1 = document.getElementById("txtFIELD4_3_4_1");
    let txtFIELD4_3_4_2 = document.getElementById("txtFIELD4_3_4_2");
    let txtFIELD4_3_4_3 = document.getElementById("txtFIELD4_3_4_3");
    let txtFIELD4_3_5_1 = document.getElementById("txtFIELD4_3_5_1");
    let txtFIELD4_3_5_2 = document.getElementById("txtFIELD4_3_5_2");
    let txtFIELD4_3_5_3 = document.getElementById("txtFIELD4_3_5_3");
    let txtFIELD4_3_6_1 = document.getElementById("txtFIELD4_3_6_1");
    let txtFIELD4_3_6_2 = document.getElementById("txtFIELD4_3_6_2");
    let txtFIELD4_3_6_3 = document.getElementById("txtFIELD4_3_6_3");

    let txtFIELD5_1 = document.getElementById("txtFIELD5_1");
    let txtFIELD5_2 = document.getElementById("txtFIELD5_2");
    let txtFIELD5_3 = document.getElementById("txtFIELD5_3");
    let txtFIELD5_4 = document.getElementById("txtFIELD5_4");

    let txtFIELD6_1_1 = document.getElementById("txtFIELD6_1_1");
    let txtFIELD6_1_2 = document.getElementById("txtFIELD6_1_2");
    let txtFIELD6_1_3 = document.getElementById("txtFIELD6_1_3");
    let txtFIELD6_2_1 = document.getElementById("txtFIELD6_2_1");
    let txtFIELD6_2_2 = document.getElementById("txtFIELD6_2_2");
    let txtFIELD6_2_3 = document.getElementById("txtFIELD6_2_3");
    let txtFIELD6_3_1 = document.getElementById("txtFIELD6_3_1");
    let txtFIELD6_3_2 = document.getElementById("txtFIELD6_3_2");
    let txtFIELD6_3_3 = document.getElementById("txtFIELD6_3_3");

    let txtFIELD7_1_1 = document.getElementById("txtFIELD7_1_1");
    let txtFIELD7_1_2 = document.getElementById("txtFIELD7_1_2");
    let txtFIELD7_1_3 = document.getElementById("txtFIELD7_1_3");

    let txtFIELD8_1 = document.getElementById("txtFIELD8_1");
    let txtFIELD8_2 = document.getElementById("txtFIELD8_2");
    let txtFIELD8_3 = document.getElementById("txtFIELD8_3");

    let txtFIELD9_1 = document.getElementById("txtFIELD9_1");
    let txtFIELD9_2 = document.getElementById("txtFIELD9_2");

    let txtFIELD10_1 = document.getElementById("txtFIELD10_1");

    let txtFIELD11_1 = document.getElementById("txtFIELD11_1");
    let txtFIELD11_2 = document.getElementById("txtFIELD11_2");

    var sectionHtml = "";
    if ((fIELD1_1_1.value == "")
        || (fIELD1_1_2.value == "")
        || (fIELD1_1_3.value == "")
        || (fIELD1_1_4.value == "")
        || (fIELD1_1_5.value == "")
        || (fIELD1_1_6.value == "")
        || (fIELD1_1_7.value == "")
        || (fIELD1_2_1.value == "")
        || (fIELD1_2_2.value == "")
        || (fIELD1_2_3.value == "")
        || (fIELD1_2_4.value == "")
        || (fIELD1_2_5.value == "")
    ) {
        if (cultureInfo == "fr") {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection1();'>Tab 1 - Nombre d’appels, d’appels incidents, de renvois, de révisions de cautionnement et de contrôles judiciaires</a></div>";
        }
        else {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection1();'>Tab 1 –	Number of appeals, cross-appeals, references, bail reviews, and judicial reviews (JRs)</a></div>";
        }
        result = false;
    }

    if ((txtFIELD2_1_1.value == "")
        || (txtFIELD2_1_2.value == "")
        || (txtFIELD2_2_1.value == "")
        || (txtFIELD2_2_1_1.value == "")
        || (txtFIELD2_2_1_2.value == "")
        || (txtFIELD2_2_1_3.value == "")
        || (txtFIELD2_2_2.value == "")
        || (txtFIELD2_2_2_1.value == "")
        || (txtFIELD2_2_2_2.value == "")
        || (txtFIELD2_2_2_3.value == "")
    ) {
        if (cultureInfo == "fr") {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection2();'>Tab 2 - Affaires civiles et criminelles décidées</a></div>";
        }
        else {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection2();'>Tab 2 – Civil and criminal case decisions</a></div>";
        }
        result = false;
    }

    if ((txtFIELD3_1.value == "")
        || (txtFIELD3_2.value == "")
    ) {
        if (cultureInfo == "fr") {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection3();'>Tab 3 - Nombre de décisions/jugements (total)</a></div>";
        }
        else {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection3();'>Tab 3 – Number of decisions/judgments (total)</a></div>";
        }
        result = false;
    }

    if ((txtFIELD4_1_1.value == "")
        || (txtFIELD4_1_2.value == "")
        || (txtFIELD4_1_3.value == "")
        || (txtFIELD4_1_4_1.value == "")
        || (txtFIELD4_1_4_2.value == "")
        || (txtFIELD4_1_4_3.value == "")
        || (txtFIELD4_1_5_1.value == "")
        || (txtFIELD4_1_5_2.value == "")
        || (txtFIELD4_1_5_3.value == "")
        || (txtFIELD4_1_6_1.value == "")
        || (txtFIELD4_1_6_2.value == "")
        || (txtFIELD4_1_6_3.value == "")
        || (txtFIELD4_2_1.value == "")
        || (txtFIELD4_2_2.value == "")
        || (txtFIELD4_2_3.value == "")
        || (txtFIELD4_2_4_1.value == "")
        || (txtFIELD4_2_4_2.value == "")
        || (txtFIELD4_2_4_3.value == "")
        || (txtFIELD4_2_5_1.value == "")
        || (txtFIELD4_2_5_2.value == "")
        || (txtFIELD4_2_5_3.value == "")
        || (txtFIELD4_2_6_1.value == "")
        || (txtFIELD4_2_6_2.value == "")
        || (txtFIELD4_2_6_3.value == "")
        || (txtFIELD4_3_1.value == "")
        || (txtFIELD4_3_2.value == "")
        || (txtFIELD4_3_3.value == "")
        || (txtFIELD4_3_4_1.value == "")
        || (txtFIELD4_3_4_2.value == "")
        || (txtFIELD4_3_4_3.value == "")
        || (txtFIELD4_3_5_1.value == "")
        || (txtFIELD4_3_5_2.value == "")
        || (txtFIELD4_3_5_3.value == "")
        || (txtFIELD4_3_6_1.value == "")
        || (txtFIELD4_3_6_2.value == "")
        || (txtFIELD4_3_6_3.value == "")
    ) {
        if (cultureInfo == "fr") {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection4();'>Tab 4 - Intervalles de temps pour les affaires civiles et criminelles</a></div>";
        }
        else {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection4();'>Tab 4 – Civil and criminal case time intervals</a></div>";
        }
        result = false;
    }

    if ((txtFIELD5_1.value == "")
        || (txtFIELD5_2.value == "")
        || (txtFIELD5_3.value == "")
        || (txtFIELD5_4.value == "")
    ) {
        if (cultureInfo == "fr") {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection5();'>Tab 5 - Nombre d’audiences en personne, virtuelles et hybrides</a></div>";
        }
        else {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection5();'>Tab 5 – Number of in-person, virtual and hybrid hearings</a></div>";
        }
        result = false;
    }

    if ((txtFIELD6_1_1.value == "")
        || (txtFIELD6_1_2.value == "")
        || (txtFIELD6_1_3.value == "")
        || (txtFIELD6_2_1.value == "")
        || (txtFIELD6_2_2.value == "")
        || (txtFIELD6_2_3.value == "")
        || (txtFIELD6_3_1.value == "")
        || (txtFIELD6_3_2.value == "")
        || (txtFIELD6_3_3.value == "")
    ) {
        if (cultureInfo == "fr") {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection6();'>Tab 6 - Nombre de requêtes et demandes</a></div>";
        }
        else {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection6();'>Tab 6 – Number of motions and applications</a></div>";
        }
        result = false;
    }

    if ((txtFIELD7_1_1.value == "")
        || (txtFIELD7_1_2.value == "")
        || (txtFIELD7_1_3.value == "")
    ) {
        if (cultureInfo == "fr") {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection7();'>Tab 7 - Personnes qui se représentent seules</a></div>";
        }
        else {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection7();'>Tab 7 – Self-Represented Litigants (SRLs)</a></div>";
        }
        result = false;
    }

    if ((txtFIELD8_1.value == "")
        || (txtFIELD8_2.value == "")
        || (txtFIELD8_3.value == "")
    ) {
        if (cultureInfo == "fr") {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection8();'>Tab 8 - Nombre de décisions/jugements rendus</a></div>";
        }
        else {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection8();'>Tab 8 – Number of decisions/judgments rendered</a></div>";
        }
        result = false;
    }

    if ((txtFIELD9_1.value == "")
        || (txtFIELD9_2.value == "")
    ) {
        if (cultureInfo == "fr") {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection9();'>Tab 9 - Nombre d’appels qui sont entendus</a></div>";
        }
        else {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection9();'>Tab 9 – Number of appeals that are heard</a></div>";
        }
        result = false;
    }

    if ((txtFIELD10_1.value == "")
    ) {
        if (cultureInfo == "fr") {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection10();'>FR - Tab 10 – Total number of  appeals, cross-appeals, references, bail reviews and JRs pending on December 31<sup>st</sup></a></div>";
        }
        else {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection10();'>Tab 10 – Total number of  appeals, cross-appeals, references, bail reviews and JRs pending on December 31<sup>st</sup></a></div>";
        }
        result = false;
    }

    if ((txtFIELD11_1.value == "")
        || (txtFIELD11_2.value == "")
    ) {
        if (cultureInfo == "fr") {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection11();'>FR - Tab 11 – Number of judges (as of December 31<sup>st</sup>)</a></div>";
        }
        else {
            sectionHtml = sectionHtml + "<div><a href='javascript:errorSection11();'>Tab 11 – Number of judges (as of December 31<sup>st</sup>)</a></div>";
        }
        result = false;
    }

    let validationModal = document.getElementById("validation-body");
    validationModal.innerHTML = sectionHtml;
    return result;
}

function hideValidationModal() {
    $('#validationModal').modal('hide');
}

function errorSection1() {
    hideValidationModal();
    let fIELD1_1_1 = document.getElementById("txtFIELD1_1_1");
    let fIELD1_1_2 = document.getElementById("txtFIELD1_1_2");
    let fIELD1_1_3 = document.getElementById("txtFIELD1_1_3");
    let fIELD1_1_4 = document.getElementById("txtFIELD1_1_4");
    let fIELD1_1_5 = document.getElementById("txtFIELD1_1_5");
    let fIELD1_1_6 = document.getElementById("txtFIELD1_1_6");
    let fIELD1_1_7 = document.getElementById("txtFIELD1_1_7");
    let fIELD1_2_1 = document.getElementById("txtFIELD1_2_1");
    let fIELD1_2_2 = document.getElementById("txtFIELD1_2_2");
    let fIELD1_2_3 = document.getElementById("txtFIELD1_2_3");
    let fIELD1_2_4 = document.getElementById("txtFIELD1_2_4");
    let fIELD1_2_5 = document.getElementById("txtFIELD1_2_5");
    setTabsBackgroundToInit();
    showDetails('details1');
    if (fIELD1_1_1.value == "") {
        document.getElementById("txtFIELD1_1_1").focus();
    }
    else if (fIELD1_1_2.value == "") {
        document.getElementById("txtFIELD1_1_2").focus();
    } 
    else if (fIELD1_1_3.value == "") {
        document.getElementById("txtFIELD1_1_3").focus();
    }
    else if (fIELD1_1_4.value == "") {
        document.getElementById("txtFIELD1_1_4").focus();
    }
    else if (fIELD1_1_5.value == "") {
        document.getElementById("txtFIELD1_1_5").focus();
    }
    else if (fIELD1_1_6.value == "") {
        document.getElementById("txtFIELD1_1_6").focus();
    }
    else if (fIELD1_1_7.value == "") {
        document.getElementById("txtFIELD1_1_7").focus();
    }
    else if (fIELD1_2_1.value == "") {
        document.getElementById("txtFIELD1_2_1").focus();
    }
    else if (fIELD1_2_2.value == "") {
        document.getElementById("txtFIELD1_2_2").focus();
    }
    else if (fIELD1_2_3.value == "") {
        document.getElementById("txtFIELD1_2_3").focus();
    }
    else if (fIELD1_2_4.value == "") {
        document.getElementById("txtFIELD1_2_4").focus();
    }
    else if (fIELD1_2_5.value == "") {
        document.getElementById("txtFIELD1_2_5").focus();
    }
}

function errorSection2() {
    hideValidationModal();
    let txtFIELD2_1_1 = document.getElementById("txtFIELD2_1_1");
    let txtFIELD2_1_2 = document.getElementById("txtFIELD2_1_2");
    let txtFIELD2_2_1 = document.getElementById("txtFIELD2_2_1");
    let txtFIELD2_2_1_1 = document.getElementById("txtFIELD2_2_1_1");
    let txtFIELD2_2_1_2 = document.getElementById("txtFIELD2_2_1_2");
    let txtFIELD2_2_1_3 = document.getElementById("txtFIELD2_2_1_3");
    let txtFIELD2_2_2 = document.getElementById("txtFIELD2_2_2");
    let txtFIELD2_2_2_1 = document.getElementById("txtFIELD2_2_2_1");
    let txtFIELD2_2_2_2 = document.getElementById("txtFIELD2_2_2_2");
    let txtFIELD2_2_2_3 = document.getElementById("txtFIELD2_2_2_3");
    setTabsBackgroundToInit();
    showDetails('details2');
    if (txtFIELD2_1_1.value == "") {
        document.getElementById("txtFIELD2_1_1").focus();
    }
    else if (txtFIELD2_1_2.value == "") {
        document.getElementById("txtFIELD2_1_2").focus();
    }
    else if (txtFIELD2_2_1.value == "") {
        document.getElementById("txtFIELD2_2_1").focus();
    }
    else if (txtFIELD2_2_1_1.value == "") {
        document.getElementById("txtFIELD2_2_1_1").focus();
    }
    else if (txtFIELD2_2_1_2.value == "") {
        document.getElementById("txtFIELD2_2_1_2").focus();
    }
    else if (txtFIELD2_2_1_3.value == "") {
        document.getElementById("txtFIELD2_2_1_3").focus();
    }
    else if (txtFIELD2_2_2.value == "") {
        document.getElementById("txtFIELD2_2_2").focus();
    }
    else if (txtFIELD2_2_2_1.value == "") {
        document.getElementById("txtFIELD2_2_2_1").focus();
    }
    else if (txtFIELD2_2_2_2.value == "") {
        document.getElementById("txtFIELD2_2_2_2").focus();
    }
    else if (txtFIELD2_2_2_3.value == "") {
        document.getElementById("txtFIELD2_2_2_3").focus();
    }
}

function errorSection3() {
    hideValidationModal();
    let txtFIELD3_1 = document.getElementById("txtFIELD3_1");
    let txtFIELD3_2 = document.getElementById("txtFIELD3_2");
    setTabsBackgroundToInit();
    showDetails('details3');
    if (txtFIELD3_1.value == "") {
        document.getElementById("txtFIELD3_1").focus();
    }
    else if (txtFIELD3_2.value == "") {
        document.getElementById("txtFIELD3_2").focus();
    }
}

function errorSection4() {
    hideValidationModal();
    let txtFIELD4_1_1 = document.getElementById("txtFIELD4_1_1");
    let txtFIELD4_1_2 = document.getElementById("txtFIELD4_1_2");
    let txtFIELD4_1_3 = document.getElementById("txtFIELD4_1_3");
    let txtFIELD4_1_4_1 = document.getElementById("txtFIELD4_1_4_1");
    let txtFIELD4_1_4_2 = document.getElementById("txtFIELD4_1_4_2");
    let txtFIELD4_1_4_3 = document.getElementById("txtFIELD4_1_4_3");
    let txtFIELD4_1_5_1 = document.getElementById("txtFIELD4_1_5_1");
    let txtFIELD4_1_5_2 = document.getElementById("txtFIELD4_1_5_2");
    let txtFIELD4_1_5_3 = document.getElementById("txtFIELD4_1_5_3");
    let txtFIELD4_1_6_1 = document.getElementById("txtFIELD4_1_6_1");
    let txtFIELD4_1_6_2 = document.getElementById("txtFIELD4_1_6_2");
    let txtFIELD4_1_6_3 = document.getElementById("txtFIELD4_1_6_3");
    let txtFIELD4_2_1 = document.getElementById("txtFIELD4_2_1");
    let txtFIELD4_2_2 = document.getElementById("txtFIELD4_2_2");
    let txtFIELD4_2_3 = document.getElementById("txtFIELD4_2_3");
    let txtFIELD4_2_4_1 = document.getElementById("txtFIELD4_2_4_1");
    let txtFIELD4_2_4_2 = document.getElementById("txtFIELD4_2_4_2");
    let txtFIELD4_2_4_3 = document.getElementById("txtFIELD4_2_4_3");
    let txtFIELD4_2_5_1 = document.getElementById("txtFIELD4_2_5_1");
    let txtFIELD4_2_5_2 = document.getElementById("txtFIELD4_2_5_2");
    let txtFIELD4_2_5_3 = document.getElementById("txtFIELD4_2_5_3");
    let txtFIELD4_2_6_1 = document.getElementById("txtFIELD4_2_6_1");
    let txtFIELD4_2_6_2 = document.getElementById("txtFIELD4_2_6_2");
    let txtFIELD4_2_6_3 = document.getElementById("txtFIELD4_2_6_3");
    let txtFIELD4_3_1 = document.getElementById("txtFIELD4_3_1");
    let txtFIELD4_3_2 = document.getElementById("txtFIELD4_3_2");
    let txtFIELD4_3_3 = document.getElementById("txtFIELD4_3_3");
    let txtFIELD4_3_4_1 = document.getElementById("txtFIELD4_3_4_1");
    let txtFIELD4_3_4_2 = document.getElementById("txtFIELD4_3_4_2");
    let txtFIELD4_3_4_3 = document.getElementById("txtFIELD4_3_4_3");
    let txtFIELD4_3_5_1 = document.getElementById("txtFIELD4_3_5_1");
    let txtFIELD4_3_5_2 = document.getElementById("txtFIELD4_3_5_2");
    let txtFIELD4_3_5_3 = document.getElementById("txtFIELD4_3_5_3");
    let txtFIELD4_3_6_1 = document.getElementById("txtFIELD4_3_6_1");
    let txtFIELD4_3_6_2 = document.getElementById("txtFIELD4_3_6_2");
    let txtFIELD4_3_6_3 = document.getElementById("txtFIELD4_3_6_3");
    setTabsBackgroundToInit();
    showDetails('details4');
    if (txtFIELD4_1_1.value == "") {
        document.getElementById("txtFIELD4_1_1").focus();
    }
    else if (txtFIELD4_1_2.value == "") {
        document.getElementById("txtFIELD4_1_2").focus();
    }
    else if (txtFIELD4_1_3.value == "") {
        document.getElementById("txtFIELD4_1_3").focus();
    }
    else if (txtFIELD4_1_4_1.value == "") {
        document.getElementById("txtFIELD4_1_4_1").focus();
    }
    else if (txtFIELD4_1_4_2.value == "") {
        document.getElementById("txtFIELD4_1_4_2").focus();
    }
    else if (txtFIELD4_1_4_3.value == "") {
        document.getElementById("txtFIELD4_1_4_3").focus();
    }
    else if (txtFIELD4_1_5_1.value == "") {
        document.getElementById("txtFIELD4_1_5_1").focus();
    }
    else if (txtFIELD4_1_5_2.value == "") {
        document.getElementById("txtFIELD4_1_5_2").focus();
    }
    else if (txtFIELD4_1_5_3.value == "") {
        document.getElementById("txtFIELD4_1_5_3").focus();
    }
    else if (txtFIELD4_1_6_1.value == "") {
        document.getElementById("txtFIELD4_1_6_1").focus();
    }
    else if (txtFIELD4_1_6_2.value == "") {
        document.getElementById("txtFIELD4_1_6_2").focus();
    }
    else if (txtFIELD4_1_6_3.value == "") {
        document.getElementById("txtFIELD4_1_6_3").focus();
    }
    else if (txtFIELD4_2_1.value == "") {
        document.getElementById("txtFIELD4_2_1").focus();
    }
    else if (txtFIELD4_2_2.value == "") {
        document.getElementById("txtFIELD4_2_2").focus();
    }
    else if (txtFIELD4_2_3.value == "") {
        document.getElementById("txtFIELD4_2_3").focus();
    }
    else if (txtFIELD4_2_4_1.value == "") {
        document.getElementById("txtFIELD4_2_4_1").focus();
    }
    else if (txtFIELD4_2_4_2.value == "") {
        document.getElementById("txtFIELD4_2_4_2").focus();
    }
    else if (txtFIELD4_2_4_3.value == "") {
        document.getElementById("txtFIELD4_2_4_3").focus();
    }
    else if (txtFIELD4_2_5_1.value == "") {
        document.getElementById("txtFIELD4_2_5_1").focus();
    }
    else if (txtFIELD4_2_5_2.value == "") {
        document.getElementById("txtFIELD4_2_5_2").focus();
    }
    else if (txtFIELD4_2_5_3.value == "") {
        document.getElementById("txtFIELD4_2_5_3").focus();
    }
    else if (txtFIELD4_2_6_1.value == "") {
        document.getElementById("txtFIELD4_2_6_1").focus();
    }
    else if (txtFIELD4_2_6_2.value == "") {
        document.getElementById("txtFIELD4_2_6_2").focus();
    }
    else if (txtFIELD4_2_6_3.value == "") {
        document.getElementById("txtFIELD4_2_6_3").focus();
    }
    else if (txtFIELD4_3_1.value == "") {
        document.getElementById("txtFIELD4_3_1").focus();
    }
    else if (txtFIELD4_3_2.value == "") {
        document.getElementById("txtFIELD4_3_2").focus();
    }
    else if (txtFIELD4_3_3.value == "") {
        document.getElementById("txtFIELD4_3_3").focus();
    }
    else if (txtFIELD4_3_4_1.value == "") {
        document.getElementById("txtFIELD4_3_4_1").focus();
    }
    else if (txtFIELD4_3_4_2.value == "") {
        document.getElementById("txtFIELD4_3_4_2").focus();
    }
    else if (txtFIELD4_3_4_3.value == "") {
        document.getElementById("txtFIELD4_3_4_3").focus();
    }
    else if (txtFIELD4_3_5_1.value == "") {
        document.getElementById("txtFIELD4_3_5_1").focus();
    }
    else if (txtFIELD4_3_5_2.value == "") {
        document.getElementById("txtFIELD4_3_5_2").focus();
    }
    else if (txtFIELD4_3_5_3.value == "") {
        document.getElementById("txtFIELD4_3_5_3").focus();
    }
    else if (txtFIELD4_3_6_1.value == "") {
        document.getElementById("txtFIELD4_3_6_1").focus();
    }
    else if (txtFIELD4_3_6_2.value == "") {
        document.getElementById("txtFIELD4_3_6_2").focus();
    }
    else if (txtFIELD4_3_6_3.value == "") {
        document.getElementById("txtFIELD4_3_6_3").focus();
    }
}

function errorSection5() {
    hideValidationModal();
    let txtFIELD5_1 = document.getElementById("txtFIELD5_1");
    let txtFIELD5_2 = document.getElementById("txtFIELD5_2");
    let txtFIELD5_3 = document.getElementById("txtFIELD5_3");
    let txtFIELD5_4 = document.getElementById("txtFIELD5_4");
    setTabsBackgroundToInit();
    showDetails('details5');
    if (txtFIELD5_1.value == "") {
        document.getElementById("txtFIELD5_1").focus();
    }
    else if (txtFIELD5_2.value == "") {
        document.getElementById("txtFIELD5_2").focus();
    }
    else if (txtFIELD5_3.value == "") {
        document.getElementById("txtFIELD5_3").focus();
    }
    else if (txtFIELD5_4.value == "") {
        document.getElementById("txtFIELD5_4").focus();
    }
}

function errorSection6() {
    hideValidationModal();
    let txtFIELD6_1_1 = document.getElementById("txtFIELD6_1_1");
    let txtFIELD6_1_2 = document.getElementById("txtFIELD6_1_2");
    let txtFIELD6_1_3 = document.getElementById("txtFIELD6_1_3");
    let txtFIELD6_2_1 = document.getElementById("txtFIELD6_2_1");
    let txtFIELD6_2_2 = document.getElementById("txtFIELD6_2_2");
    let txtFIELD6_2_3 = document.getElementById("txtFIELD6_2_3");
    let txtFIELD6_3_1 = document.getElementById("txtFIELD6_3_1");
    let txtFIELD6_3_2 = document.getElementById("txtFIELD6_3_2");
    let txtFIELD6_3_3 = document.getElementById("txtFIELD6_3_3");
    setTabsBackgroundToInit();
    showDetails('details6');
    if (txtFIELD6_1_1.value == "") {
        document.getElementById("txtFIELD6_1_1").focus();
    }
    else if (txtFIELD6_1_2.value == "") {
        document.getElementById("txtFIELD6_1_2").focus();
    }
    else if (txtFIELD6_1_3.value == "") {
        document.getElementById("txtFIELD6_1_3").focus();
    }
    else if (txtFIELD6_2_1.value == "") {
        document.getElementById("txtFIELD6_2_1").focus();
    }
    else if (txtFIELD6_2_2.value == "") {
        document.getElementById("txtFIELD6_2_2").focus();
    }
    else if (txtFIELD6_2_3.value == "") {
        document.getElementById("txtFIELD6_2_3").focus();
    }
    else if (txtFIELD6_3_1.value == "") {
        document.getElementById("txtFIELD6_3_1").focus();
    }
    else if (txtFIELD6_3_2.value == "") {
        document.getElementById("txtFIELD6_3_2").focus();
    }
    else if (txtFIELD6_3_3.value == "") {
        document.getElementById("txtFIELD6_3_3").focus();
    }
}

function errorSection7() {
    hideValidationModal();
    let txtFIELD7_1_1 = document.getElementById("txtFIELD7_1_1");
    let txtFIELD7_1_2 = document.getElementById("txtFIELD7_1_2");
    let txtFIELD7_1_3 = document.getElementById("txtFIELD7_1_3");
    setTabsBackgroundToInit();
    showDetails('details7');
    if (txtFIELD7_1_1.value == "") {
        document.getElementById("txtFIELD7_1_1").focus();
    }
    else if (txtFIELD7_1_2.value == "") {
        document.getElementById("txtFIELD7_1_2").focus();
    }
    else if (txtFIELD7_1_3.value == "") {
        document.getElementById("txtFIELD7_1_3").focus();
    }
}

function errorSection8() {
    hideValidationModal();
    let txtFIELD8_1 = document.getElementById("txtFIELD8_1");
    let txtFIELD8_2 = document.getElementById("txtFIELD8_2");
    let txtFIELD8_3 = document.getElementById("txtFIELD8_3");
    setTabsBackgroundToInit();
    showDetails('details8');
    if (txtFIELD8_1.value == "") {
        document.getElementById("txtFIELD8_1").focus();
    }
    else if (txtFIELD8_2.value == "") {
        document.getElementById("txtFIELD8_2").focus();
    }
    else if (txtFIELD8_3.value == "") {
        document.getElementById("txtFIELD8_3").focus();
    }
}

function errorSection9() {
    hideValidationModal();
    let txtFIELD9_1 = document.getElementById("txtFIELD9_1");
    let txtFIELD9_2 = document.getElementById("txtFIELD9_2");
    setTabsBackgroundToInit();
    showDetails('details9');
    if (txtFIELD9_1.value == "") {
        document.getElementById("txtFIELD9_1").focus();
    }
    else if (txtFIELD9_2.value == "") {
        document.getElementById("txtFIELD9_2").focus();
    }
}

function errorSection10() {
    hideValidationModal();
    let txtFIELD10_1 = document.getElementById("txtFIELD10_1");
    setTabsBackgroundToInit();
    showDetails('details10');
    if (txtFIELD10_1.value == "") {
        document.getElementById("txtFIELD10_1").focus();
    }
}

function errorSection11() {
    hideValidationModal();
    let txtFIELD11_1 = document.getElementById("txtFIELD11_1");
    let txtFIELD11_2 = document.getElementById("txtFIELD11_2");
    setTabsBackgroundToInit();
    showDetails('details11');
    if (txtFIELD11_1.value == "") {
        document.getElementById("txtFIELD11_1").focus();
    }
    else if (txtFIELD11_2.value == "") {
        document.getElementById("txtFIELD11_2").focus();
    }
}

function validateFields(formName) {

    let form = document.getElementById(formName);
    let errors = [];

    // Clear previous alerts
    let summary = document.getElementById("validationSummary");
    summary.classList.add('d-none');

    // Check each required input
    form.querySelectorAll('input, select, textarea').forEach(field => {
        if (!field.checkValidity()) {
            let msg = field.getAttribute("data-msg");
            let num = field.getAttribute("data-num");
            if (num == "") {
                errors.push(`<div class="row"><div class="col-md-11">${msg}</div></div>`);
            }
            else {
                errors.push(`<div class="row"><div class="col-md-1">${num}</div><div class="col-md-11">${msg}</div></div>`);
            }     
            field.classList.add('is-invalid'); // Add red border
        } else {
            field.classList.remove('is-invalid');
        }
    });

    // If errors exist, show in summary
    if (errors.length > 0) {
        let summary = document.getElementById("validationSummary");
        summary.classList.remove("d-none");
        var errorL = document.getElementById("errorList");
        errorL.innerHTML = "";
        errors.forEach(errormsg => {    
            var li = document.createElement("li");         
            li.innerHTML = errormsg;
            errorL.appendChild(li);

        }
        );
        return false;
    } else {
        return true; // Or perform AJAX submit
    }
}

//function saveDraft() {
//    var casModel =
//    {
//        appId: "CAACS",
//        region: "NEWRECORD",
//        uuid: $("#modelUuid").val(),
//        nodes: [{
//            uuid: $("#nodeUuid").val(),
//            fields: [
//                        {
//                           name: "EXTERNALUSERID",
//                           value: $("#emailAddress").val(),
//                        },
//            {
//                        name:"STATUS",
//                        value: "DRAFT",
//                    },

//            {
//                        name:"INPUT",
//                        value: new Date(),
//                    },

//            {
//                        name:"COURT",
//                        value: $("#txtCOURT").val(),
//                    },

//            {
//                        name:"REPORTINGYEAR",
//                        value: $("#intREPORTINGYEAR").val(),
//                    },

//            {
//                        name:"DATEFROM",
//                        value: $("#dtFROM").val(),
//                    },

//            {
//                        name:"DATETO",
//                        value: $("#dtTO").val(),
//                    },
//            {
//                        name:"FIELD1_1_1",
//                        value: $("#txtFIELD1_1_1").val(),
//                    },

//            {
//                        name:"FIELD1_1_2",
//                        value: $("#txtFIELD1_1_2").val(),
//                    },
//            {
//                        name:"FIELD1_1_3",
//                        value: $("#txtFIELD1_1_3").val(),
//                    },

//            {
//                        name:"FIELD1_1_4",
//                        value: $("#txtFIELD1_1_4").val(),
//                    },

//            {
//                        name:"FIELD1_1_5",
//                        value: $("#txtFIELD1_1_5").val(),
//                    },
//            {
//                        name:"FIELD1_1_6",
//                        value: $("#txtFIELD1_1_6").val(),
//                    },
//            {
//                        name:"FIELD1_1_7",
//                        value: $("#txtFIELD1_1_7").val(),
//                    },
//            {
//                        name:"COMMENTSECTION1",
//                        value: $("#txtFIELD_1_Comments").val(),
//                    },
//            {
//                        name:"FIELD1_2_1",
//                        value: $("#txtFIELD1_2_1").val(),
//                    },
//            {
//                        name:"FIELD1_2_2",
//                        value: $("#txtFIELD1_2_2").val(),
//                    },
//            {
//                        name:"FIELD1_2_3",
//                        value: $("#txtFIELD1_2_3").val(),
//                    },
//            {
//                        name:"FIELD1_2_4",
//                        value: $("#txtFIELD1_2_4").val(),
//                    },

//            {
//                        name:"FIELD1_2_5",
//                        value: $("#txtFIELD1_2_5").val(),
//                    },
//            {
//                        name:"FIELD2_1_1",
//                        value: $("#txtFIELD2_1_1").val(),
//                    },
//            {
//                        name:"FIELD2_1_2",
//                        value: $("#txtFIELD2_1_2").val(),
//                },  
//                {
//                    name: "FIELD2_2_1",
//                    value: $("#txtFIELD2_2_1").val(),
//                },
               
//            {
//                        name:"FIELD2_2_1_1",
//                        value: $("#txtFIELD2_2_1_1").val(),
//                    },         
//            {
//                        name:"FIELD2_2_1_2",
//                        value: $("#txtFIELD2_2_1_2").val(),
//                    },              
//            {
//                        name:"FIELD2_2_1_3",
//                        value: $("#txtFIELD2_2_1_3").val(),
//                },   
//                {
//                    name: "FIELD2_2_2",
//                    value: $("#txtFIELD2_2_2").val(),
//                },
//            {
//                        name:"FIELD2_2_2_1",
//                        value: $("#txtFIELD2_2_2_1").val(),
//                    },            
//            {
//                        name:"FIELD2_2_2_2",
//                        value: $("#txtFIELD2_2_2_2").val(),
//                    },               
//            {
//                        name:"FIELD2_2_2_3",
//                        value: $("#txtFIELD2_2_2_3").val(),
//                    },                
//            {
//                        name:"COMMENTSECTION2",
//                        value: $("#txtFIELD_2_Comments").val(),
//                    },         
//            {
//                        name:"FIELD3_1",
//                        value: $("#txtFIELD3_1").val(),
//                    },             
//            {
//                        name:"FIELD3_2",
//                        value: $("#txtFIELD3_2").val(),
//                    },                
//            {
//                        name:"COMMENTSECTION3",
//                        value: $("#txtFIELD_3_Comments").val(),
//                    },            
//            {
//                        name:"FIELD4_1_1",
//                        value: $("#txtFIELD4_1_1").val(),
//                    },                
//            {
//                        name:"FIELD4_1_2",
//                        value: $("#txtFIELD4_1_2").val(),
//                    },              
//            {
//                        name:"FIELD4_1_3",
//                        value: $("#txtFIELD4_1_3").val(),
//                    },                
//            {
//                        name:"FIELD4_1_4_1",
//                        value: $("#txtFIELD4_1_4_1").val(),
//                    },              
//            {
//                        name:"FIELD4_1_4_2",
//                        value: $("#txtFIELD4_1_4_2").val(),
//                    },               
//            {
//                        name:"FIELD4_1_4_3",
//                        value: $("#txtFIELD4_1_4_3").val(),
//                    },               
//            {
//                        name:"FIELD4_1_5_1",
//                        value: $("#txtFIELD4_1_5_1").val(),
//                    },                
//            {
//                        name:"FIELD4_1_5_2",
//                        value: $("#txtFIELD4_1_5_2").val(),
//                    },            
//            {
//                        name:"FIELD4_1_5_3",
//                        value: $("#txtFIELD4_1_5_3").val(),
//                    },               
//            {
//                        name:"FIELD4_1_6_1",
//                        value: $("#txtFIELD4_1_6_1").val(),
//                    },            
//            {
//                        name:"FIELD4_1_6_2",
//                        value: $("#txtFIELD4_1_6_2").val(),
//                    },               
//            {
//                        name:"FIELD4_1_6_3",
//                        value: $("#txtFIELD4_1_6_3").val(),
//                    },            
//            {
//                        name:"FIELD4_2_1",
//                        value: $("#txtFIELD4_2_1").val(),
//                    },              
//            {
//                        name:"FIELD4_2_2",
//                        value: $("#txtFIELD4_2_2").val(),
//                    },              
//            {
//                        name:"FIELD4_2_3",
//                        value: $("#txtFIELD4_2_3").val(),
//                    },               
//            {
//                        name:"FIELD4_2_4_1",
//                        value: $("#txtFIELD4_2_4_1").val(),
//                    },               
//            {
//                        name:"FIELD4_2_4_2",
//                        value: $("#txtFIELD4_2_4_2").val(),
//                    },            
//            {
//                        name:"FIELD4_2_4_3",
//                        value: $("#txtFIELD4_2_4_3").val(),
//                    },              
//            {
//                        name:"FIELD4_2_5_1",
//                        value: $("#txtFIELD4_2_5_1").val(),
//                    },           
//            {
//                        name:"FIELD4_2_5_2",
//                        value: $("#txtFIELD4_2_5_2").val(),
//                    },        
//            {
//                        name:"FIELD4_2_5_3",
//                        value: $("#txtFIELD4_2_5_3").val(),
//                    },          
//            {
//                        name:"FIELD4_2_6_1",
//                        value: $("#txtFIELD4_2_6_1").val(),
//                    },              
//            {
//                        name:"FIELD4_2_6_2",
//                        value: $("#txtFIELD4_2_6_2").val(),
//                    },             
//            {
//                        name:"FIELD4_2_6_3",
//                        value: $("#txtFIELD4_2_6_3").val(),
//                    },             
//            {
//                        name:"FIELD4_3_1",
//                        value: $("#txtFIELD4_3_1").val(),
//                    },

                
//            {
//                        name:"FIELD4_3_2",
//                        value: $("#txtFIELD4_3_2").val(),
//                    },

                
//            {
//                        name:"FIELD4_3_3",
//                        value: $("#txtFIELD4_3_3").val(),
//                    },

                
//            {
//                        name:"FIELD4_3_4_1",
//                        value: $("#txtFIELD4_3_4_1").val(),
//                    },

                
//            {
//                        name:"FIELD4_3_4_2",
//                        value: $("#txtFIELD4_3_4_2").val(),
//                    },

                
//            {
//                        name:"FIELD4_3_4_3",
//                        value: $("#txtFIELD4_3_4_3").val(),
//                    },

                
//            {
//                        name:"FIELD4_3_5_1",
//                        value: $("#txtFIELD4_3_5_1").val(),
//                    },

                
//            {
//                        name:"FIELD4_3_5_2",
//                        value: $("#txtFIELD4_3_5_2").val(),
//                    },

                
//            {
//                        name:"FIELD4_3_5_3",
//                        value: $("#txtFIELD4_3_5_3").val(),
//                    },

                
//            {
//                        name:"FIELD4_3_6_1",
//                        value: $("#txtFIELD4_3_6_1").val(),
//                    },

                
//            {
//                        name:"FIELD4_3_6_2",
//                        value: $("#txtFIELD4_3_6_2").val(),
//                    },

                
//            {
//                        name:"FIELD4_3_6_3",
//                        value: $("#txtFIELD4_3_6_3").val(),
//                    },

                
//            {
//                        name:"COMMENTSECTION4",
//                        value: $("#txtFIELD_4_Comments").val(),
//                    },
                
//            {
//                        name:"FIELD5_1",
//                        value: $("#txtFIELD5_1").val(),
//                    },

                
//            {
//                        name:"FIELD5_2",
//                        value: $("#txtFIELD5_2").val(),
//                    },

                
//            {
//                        name:"FIELD5_3",
//                        value: $("#txtFIELD5_3").val(),
//                    },

                
//            {
//                        name:"FIELD5_4",
//                        value: $("#txtFIELD5_4").val(),
//                    },

                
//            {
//                        name:"COMMENTSECTION5",
//                        value: $("#txtFIELD_5_Comments").val(),
//                    },
                
//            {
//                        name:"FIELD6_1_1",
//                        value: $("#txtFIELD6_1_1").val(),
//                    },
//            {
//                        name:"FIELD6_1_2",
//                        value: $("#txtFIELD6_1_2").val(),
//                    },                
//            {
//                        name:"FIELD6_1_3",
//                        value: $("#txtFIELD6_1_3").val(),
//                    },              
//            {
//                        name:"FIELD6_2_1",
//                        value: $("#txtFIELD6_2_1").val(),
//                    },

                
//            {
//                        name:"FIELD6_2_2",
//                        value: $("#txtFIELD6_2_2").val(),
//                    },

                
//            {
//                        name:"FIELD6_2_3",
//                        value: $("#txtFIELD6_2_3").val(),
//                    },

                
//            {
//                        name:"FIELD6_3_1",
//                        value: $("#txtFIELD6_3_1").val(),
//                    },

                
//            {
//                        name:"FIELD6_3_2",
//                        value: $("#txtFIELD6_3_2").val(),
//                    },

                
//            {
//                        name:"FIELD6_3_3",
//                        value: $("#txtFIELD6_3_3").val(),
//                    },

                
//            {
//                        name:"COMMENTSECTION6",
//                        value: $("#txtFIELD_6_Comments").val(),
//                    },
                
//            {
//                        name:"FIELD7_1_1",
//                        value: $("#txtFIELD7_1_1").val(),
//                    },

                
//            {
//                        name:"FIELD7_1_2",
//                        value: $("#txtFIELD7_1_2").val(),
//                    },

                
//            {
//                        name:"FIELD7_1_3",
//                        value: $("#txtFIELD7_1_3").val(),
//                    },

                
//            {
//                        name:"COMMENTSECTION7",
//                        value: $("#txtFIELD_7_Comments").val(),
//                    },
                
//            {
//                        name:"FIELD8_1",
//                        value: $("#txtFIELD8_1").val(),
//                    },

                
//            {
//                        name:"FIELD8_2",
//                        value: $("#txtFIELD8_2").val(),
//                    },

                
//            {
//                        name:"FIELD8_3",
//                        value: $("#txtFIELD8_3").val(),
//                    },

                
//            {
//                        name:"COMMENTSECTION8",
//                        value: $("#txtFIELD_8_Comments").val(),
//                    },
                
//            {
//                        name:"FIELD9_1",
//                        value: $("#txtFIELD9_1").val(),
//                    },

                
//            {
//                        name:"FIELD9_2",
//                        value: $("#txtFIELD9_2").val(),
//                    },

                
//            {
//                        name:"COMMENTSECTION9",
//                        value: $("#txtFIELD_9_Comments").val(),
//                    },
                
//            {
//                        name:"FIELD10_1",
//                        value: $("#txtFIELD10_1").val(),
//                    },           
//            {
//                        name:"COMMENTSECTION10",
//                        value: $("#txtFIELD_10_Comments").val(),
//                    },
                
//            {
//                        name:"FIELD11_1",
//                        value: $("#txtFIELD11_1").val(),
//                    },

                
//            {
//                        name:"FIELD11_2",
//                        value: $("#txtFIELD11_2").val(),
//                    },

                
//            {
//                        name:"COMMENTSECTION11",
//                        value: $("#txtFIELD_11_Comments").val(),
//                    }           
//            ]
//        }]     
//    }

//    $.ajax({
//        url: $("#apiUrlSave").val(),
//        type: 'POST',
//        data: JSON.stringify(casModel), // convert to JSON
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',
//        success: function (response) {
//            console.log(response);
//            $("#modelUuid").val(response.rootUuid);
//            $("#nodeUuid").val(response.nodes[0].uuid);
//            $("#emailAddress").val(response.nodes[0].fields[0].value);
//            //$('#savedSuccessfullyMessage').removeAttr("hidden");
//            //alert("The draft saved successfully.");
//            $('#draftSavedSuccessfully').modal('show');
//            //setTimeout(function () {
//            //    document.getElementById("savedSuccessfullyMessage").style.display = "none";
//            //}, 10000);
//        },
//        error: function (err) {
//            //console.error(err);
//            $('#draftSavedFailed').modal('show');
//            //alert("The draft save failed");
//        }
//    });

//}

function hideSuccessModal() {
    $('#draftSavedSuccessfully').modal('hide');
}

function hideFailedModal() {
    $('#draftSavedFailed').modal('hide');
}

var retrievedRecord = {};

//function retrieveDraft() {
//    var courtName = document.getElementById("txtCOURT").value;
//    var reportingYear = document.getElementById("intREPORTINGYEAR").value;
//    var retrieveObj = {
//        "appId": "CAACS",
//        "region": "NEWRECORD",
//        "summaryPage": {
//            "pageSize": 1,
//            "pageNumber": 1,
//            "offset": 0,
//            "pageCount": 0,
//            "sortFieldName": "DOCKET",
//            "sortDirection": "DESC",
//            "showRestrictedItems": true
//        },
//        "searchParams": [
//            {
//                "fieldName": "STATUS",
//                "operator": "EQUAL",
//                "values": [
//                    "DRAFT"
//                ]
//            },
//            {
//                "fieldName": "COURT",
//                "operator": "EQUAL",
//                "values": [
//                    courtName
//                ]
//            },
//            {
//                "fieldName": "REPORTINGYEAR",
//                "operator": "EQUAL",
//                "values": [
//                    reportingYear
//                ]
//            }
//        ]
//    }

//    $.ajax({
//        url: $("#apiUrlRetrieve").val(),
//        type: 'POST',
//        data: JSON.stringify(retrieveObj), // convert to JSON
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',
//        success: function (response) {
//            console.log(response);
//            retrievedRecord = response;
//            var data = retrievedRecord;

//            const rootKey = Object.keys(data)[0];
//            const childKey = Object.keys(data[rootKey])[0];

//            const guid = data[rootKey][childKey][0].guid;

//            $("#modelUuid").val(guid);
//            $("#nodeUuid").val(guid);
//            //$("#emailAddress").val(response.nodes[0].fields[0].value);
//            //$('#savedSuccessfullyMessage').removeAttr("hidden");
//            //alert("The draft saved successfully.");
//            if (Object.keys(response)[0] != null) {
//                $('#draftFound').modal('show');
//            }
//            //setTimeout(function () {
//            //    document.getElementById("savedSuccessfullyMessage").style.display = "none";
//            //}, 10000);
//        },
//        error: function (err) {
//            //console.error(err);
//            $('#draftRetrievalFailed').modal('show');
//            //alert("The draft save failed");
//        }
//    });

//}

function hideFoundModal() {
    $('#draftFound').modal('hide');
}

function hideFailedRetrieval() {
    $('#draftRetrievalFailed').modal('hide');
}

function deleteFoundModal(){
    var form = document.getElementById("createForm");
    form.action = "/Create/Create?deleteDraft=true";
    form.method = "post";
    form.submit();
}

//function deleteFoundModal() {
//    var casModel =
//    {
//        appId: "CAACS",
//        region: "NEWRECORD",
//        uuid: $("#modelUuid").val(),
//        nodes: [{
//            uuid: $("#nodeUuid").val(),
//            fields: [
//                {
//                    name: "EXTERNALUSERID",
//                    value: $("#emailAddress").val(),
//                },
//                {
//                    name: "STATUS",
//                    value: "DELETED",
//                },

//                {
//                    name: "INPUT",
//                    value: new Date(),
//                },

//                {
//                    name: "COURT",
//                    value: $("#txtCOURT").val(),
//                },

//                {
//                    name: "REPORTINGYEAR",
//                    value: $("#intREPORTINGYEAR").val(),
//                },

//                {
//                    name: "DATEFROM",
//                    value: $("#dtFROM").val(),
//                },

//                {
//                    name: "DATETO",
//                    value: $("#dtTO").val(),
//                },
//                {
//                    name: "FIELD1_1_1",
//                    value: $("#txtFIELD1_1_1").val(),
//                },

//                {
//                    name: "FIELD1_1_2",
//                    value: $("#txtFIELD1_1_2").val(),
//                },
//                {
//                    name: "FIELD1_1_3",
//                    value: $("#txtFIELD1_1_3").val(),
//                },

//                {
//                    name: "FIELD1_1_4",
//                    value: $("#txtFIELD1_1_4").val(),
//                },

//                {
//                    name: "FIELD1_1_5",
//                    value: $("#txtFIELD1_1_5").val(),
//                },
//                {
//                    name: "FIELD1_1_6",
//                    value: $("#txtFIELD1_1_6").val(),
//                },
//                {
//                    name: "FIELD1_1_7",
//                    value: $("#txtFIELD1_1_7").val(),
//                },
//                {
//                    name: "COMMENTSECTION1",
//                    value: $("#txtFIELD_1_Comments").val(),
//                },
//                {
//                    name: "FIELD1_2_1",
//                    value: $("#txtFIELD1_2_1").val(),
//                },
//                {
//                    name: "FIELD1_2_2",
//                    value: $("#txtFIELD1_2_2").val(),
//                },
//                {
//                    name: "FIELD1_2_3",
//                    value: $("#txtFIELD1_2_3").val(),
//                },
//                {
//                    name: "FIELD1_2_4",
//                    value: $("#txtFIELD1_2_4").val(),
//                },

//                {
//                    name: "FIELD1_2_5",
//                    value: $("#txtFIELD1_2_5").val(),
//                },
//                {
//                    name: "FIELD2_1_1",
//                    value: $("#txtFIELD2_1_1").val(),
//                },
//                {
//                    name: "FIELD2_1_2",
//                    value: $("#txtFIELD2_1_2").val(),
//                },
//                {
//                    name: "FIELD2_2_1",
//                    value: $("#txtFIELD2_2_1").val(),
//                },

//                {
//                    name: "FIELD2_2_1_1",
//                    value: $("#txtFIELD2_2_1_1").val(),
//                },
//                {
//                    name: "FIELD2_2_1_2",
//                    value: $("#txtFIELD2_2_1_2").val(),
//                },
//                {
//                    name: "FIELD2_2_1_3",
//                    value: $("#txtFIELD2_2_1_3").val(),
//                },
//                {
//                    name: "FIELD2_2_2",
//                    value: $("#txtFIELD2_2_2").val(),
//                },
//                {
//                    name: "FIELD2_2_2_1",
//                    value: $("#txtFIELD2_2_2_1").val(),
//                },
//                {
//                    name: "FIELD2_2_2_2",
//                    value: $("#txtFIELD2_2_2_2").val(),
//                },
//                {
//                    name: "FIELD2_2_2_3",
//                    value: $("#txtFIELD2_2_2_3").val(),
//                },
//                {
//                    name: "COMMENTSECTION2",
//                    value: $("#txtFIELD_2_Comments").val(),
//                },
//                {
//                    name: "FIELD3_1",
//                    value: $("#txtFIELD3_1").val(),
//                },
//                {
//                    name: "FIELD3_2",
//                    value: $("#txtFIELD3_2").val(),
//                },
//                {
//                    name: "COMMENTSECTION3",
//                    value: $("#txtFIELD_3_Comments").val(),
//                },
//                {
//                    name: "FIELD4_1_1",
//                    value: $("#txtFIELD4_1_1").val(),
//                },
//                {
//                    name: "FIELD4_1_2",
//                    value: $("#txtFIELD4_1_2").val(),
//                },
//                {
//                    name: "FIELD4_1_3",
//                    value: $("#txtFIELD4_1_3").val(),
//                },
//                {
//                    name: "FIELD4_1_4_1",
//                    value: $("#txtFIELD4_1_4_1").val(),
//                },
//                {
//                    name: "FIELD4_1_4_2",
//                    value: $("#txtFIELD4_1_4_2").val(),
//                },
//                {
//                    name: "FIELD4_1_4_3",
//                    value: $("#txtFIELD4_1_4_3").val(),
//                },
//                {
//                    name: "FIELD4_1_5_1",
//                    value: $("#txtFIELD4_1_5_1").val(),
//                },
//                {
//                    name: "FIELD4_1_5_2",
//                    value: $("#txtFIELD4_1_5_2").val(),
//                },
//                {
//                    name: "FIELD4_1_5_3",
//                    value: $("#txtFIELD4_1_5_3").val(),
//                },
//                {
//                    name: "FIELD4_1_6_1",
//                    value: $("#txtFIELD4_1_6_1").val(),
//                },
//                {
//                    name: "FIELD4_1_6_2",
//                    value: $("#txtFIELD4_1_6_2").val(),
//                },
//                {
//                    name: "FIELD4_1_6_3",
//                    value: $("#txtFIELD4_1_6_3").val(),
//                },
//                {
//                    name: "FIELD4_2_1",
//                    value: $("#txtFIELD4_2_1").val(),
//                },
//                {
//                    name: "FIELD4_2_2",
//                    value: $("#txtFIELD4_2_2").val(),
//                },
//                {
//                    name: "FIELD4_2_3",
//                    value: $("#txtFIELD4_2_3").val(),
//                },
//                {
//                    name: "FIELD4_2_4_1",
//                    value: $("#txtFIELD4_2_4_1").val(),
//                },
//                {
//                    name: "FIELD4_2_4_2",
//                    value: $("#txtFIELD4_2_4_2").val(),
//                },
//                {
//                    name: "FIELD4_2_4_3",
//                    value: $("#txtFIELD4_2_4_3").val(),
//                },
//                {
//                    name: "FIELD4_2_5_1",
//                    value: $("#txtFIELD4_2_5_1").val(),
//                },
//                {
//                    name: "FIELD4_2_5_2",
//                    value: $("#txtFIELD4_2_5_2").val(),
//                },
//                {
//                    name: "FIELD4_2_5_3",
//                    value: $("#txtFIELD4_2_5_3").val(),
//                },
//                {
//                    name: "FIELD4_2_6_1",
//                    value: $("#txtFIELD4_2_6_1").val(),
//                },
//                {
//                    name: "FIELD4_2_6_2",
//                    value: $("#txtFIELD4_2_6_2").val(),
//                },
//                {
//                    name: "FIELD4_2_6_3",
//                    value: $("#txtFIELD4_2_6_3").val(),
//                },
//                {
//                    name: "FIELD4_3_1",
//                    value: $("#txtFIELD4_3_1").val(),
//                },


//                {
//                    name: "FIELD4_3_2",
//                    value: $("#txtFIELD4_3_2").val(),
//                },


//                {
//                    name: "FIELD4_3_3",
//                    value: $("#txtFIELD4_3_3").val(),
//                },


//                {
//                    name: "FIELD4_3_4_1",
//                    value: $("#txtFIELD4_3_4_1").val(),
//                },


//                {
//                    name: "FIELD4_3_4_2",
//                    value: $("#txtFIELD4_3_4_2").val(),
//                },


//                {
//                    name: "FIELD4_3_4_3",
//                    value: $("#txtFIELD4_3_4_3").val(),
//                },


//                {
//                    name: "FIELD4_3_5_1",
//                    value: $("#txtFIELD4_3_5_1").val(),
//                },


//                {
//                    name: "FIELD4_3_5_2",
//                    value: $("#txtFIELD4_3_5_2").val(),
//                },


//                {
//                    name: "FIELD4_3_5_3",
//                    value: $("#txtFIELD4_3_5_3").val(),
//                },


//                {
//                    name: "FIELD4_3_6_1",
//                    value: $("#txtFIELD4_3_6_1").val(),
//                },


//                {
//                    name: "FIELD4_3_6_2",
//                    value: $("#txtFIELD4_3_6_2").val(),
//                },


//                {
//                    name: "FIELD4_3_6_3",
//                    value: $("#txtFIELD4_3_6_3").val(),
//                },


//                {
//                    name: "COMMENTSECTION4",
//                    value: $("#txtFIELD_4_Comments").val(),
//                },

//                {
//                    name: "FIELD5_1",
//                    value: $("#txtFIELD5_1").val(),
//                },


//                {
//                    name: "FIELD5_2",
//                    value: $("#txtFIELD5_2").val(),
//                },


//                {
//                    name: "FIELD5_3",
//                    value: $("#txtFIELD5_3").val(),
//                },


//                {
//                    name: "FIELD5_4",
//                    value: $("#txtFIELD5_4").val(),
//                },


//                {
//                    name: "COMMENTSECTION5",
//                    value: $("#txtFIELD_5_Comments").val(),
//                },

//                {
//                    name: "FIELD6_1_1",
//                    value: $("#txtFIELD6_1_1").val(),
//                },
//                {
//                    name: "FIELD6_1_2",
//                    value: $("#txtFIELD6_1_2").val(),
//                },
//                {
//                    name: "FIELD6_1_3",
//                    value: $("#txtFIELD6_1_3").val(),
//                },
//                {
//                    name: "FIELD6_2_1",
//                    value: $("#txtFIELD6_2_1").val(),
//                },


//                {
//                    name: "FIELD6_2_2",
//                    value: $("#txtFIELD6_2_2").val(),
//                },


//                {
//                    name: "FIELD6_2_3",
//                    value: $("#txtFIELD6_2_3").val(),
//                },


//                {
//                    name: "FIELD6_3_1",
//                    value: $("#txtFIELD6_3_1").val(),
//                },


//                {
//                    name: "FIELD6_3_2",
//                    value: $("#txtFIELD6_3_2").val(),
//                },


//                {
//                    name: "FIELD6_3_3",
//                    value: $("#txtFIELD6_3_3").val(),
//                },


//                {
//                    name: "COMMENTSECTION6",
//                    value: $("#txtFIELD_6_Comments").val(),
//                },

//                {
//                    name: "FIELD7_1_1",
//                    value: $("#txtFIELD7_1_1").val(),
//                },


//                {
//                    name: "FIELD7_1_2",
//                    value: $("#txtFIELD7_1_2").val(),
//                },


//                {
//                    name: "FIELD7_1_3",
//                    value: $("#txtFIELD7_1_3").val(),
//                },


//                {
//                    name: "COMMENTSECTION7",
//                    value: $("#txtFIELD_7_Comments").val(),
//                },

//                {
//                    name: "FIELD8_1",
//                    value: $("#txtFIELD8_1").val(),
//                },


//                {
//                    name: "FIELD8_2",
//                    value: $("#txtFIELD8_2").val(),
//                },


//                {
//                    name: "FIELD8_3",
//                    value: $("#txtFIELD8_3").val(),
//                },


//                {
//                    name: "COMMENTSECTION8",
//                    value: $("#txtFIELD_8_Comments").val(),
//                },

//                {
//                    name: "FIELD9_1",
//                    value: $("#txtFIELD9_1").val(),
//                },


//                {
//                    name: "FIELD9_2",
//                    value: $("#txtFIELD9_2").val(),
//                },


//                {
//                    name: "COMMENTSECTION9",
//                    value: $("#txtFIELD_9_Comments").val(),
//                },

//                {
//                    name: "FIELD10_1",
//                    value: $("#txtFIELD10_1").val(),
//                },
//                {
//                    name: "COMMENTSECTION10",
//                    value: $("#txtFIELD_10_Comments").val(),
//                },

//                {
//                    name: "FIELD11_1",
//                    value: $("#txtFIELD11_1").val(),
//                },


//                {
//                    name: "FIELD11_2",
//                    value: $("#txtFIELD11_2").val(),
//                },


//                {
//                    name: "COMMENTSECTION11",
//                    value: $("#txtFIELD_11_Comments").val(),
//                }
//            ]
//        }]
//    }

//    $.ajax({
//        url: $("#apiUrlSave").val(),
//        type: 'POST',
//        data: JSON.stringify(casModel), // convert to JSON
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',
//        success: function (response) {
//            console.log(response);
//            //$("#modelUuid").val(response.rootUuid);
//            //$("#nodeUuid").val(response.nodes[0].uuid);
//            //$("#emailAddress").val(response.nodes[0].fields[0].value);
//            //$('#savedSuccessfullyMessage').removeAttr("hidden");
//            //alert("The draft saved successfully.");
//            /*$('#draftSavedSuccessfully').modal('show');*/
//            //setTimeout(function () {
//            //    document.getElementById("savedSuccessfullyMessage").style.display = "none";
//            //}, 10000);
//            $('#draftFound').modal('hide');
//        },
//        error: function (err) {
//            //console.error(err);
//            $('#draftFound').modal('hide');
//            $('#draftDeleteFailed').modal('show');
//            //alert("The draft save failed");
//        }
//    });

    
//}

function hideFailedDelete() {
    $('#draftDeleteFailed').modal('hide');
}

function loadFoundRecord() {
    var form = document.getElementById("createForm");
    form.action = "/Create/Create?loadRecord=true";
    form.method = "post";
    form.submit();
}

//function loadFoundRecord() {
//    var data = retrievedRecord;

//    const rootKey = Object.keys(data)[0];
//    const childKey = Object.keys(data[rootKey])[0];

//    const guid = data[rootKey][childKey][0].guid;

//    $("#modelUuid").val(guid);
//    $("#nodeUuid").val(guid);

//    const fields = data[rootKey][childKey][0].fields;

//    fields.forEach(f => {
//        console.log(f.name, f.value);
//        switch (f.name) {
//            case "EXTERNALUSERID": $("#emailAddress").val(f.value); break;
//            //case "STATUS": $("#emailAddress").val(f.value); break;
//            //case "INPUT": $("#emailAddress").val(f.value); break;
//            case "COURT": $("#txtCOURT").val(f.value); break;
//            case "REPORTINGYEAR": $("#intREPORTINGYEAR").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "DATEFROM": $("#dtFROM").val(f.value.split("T")[0]); break;
//            case "DATETO": $("#dtTO").val(f.value.split("T")[0]); break;
//            case "FIELD1_1_1": $("#txtFIELD1_1_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD1_1_2": $("#txtFIELD1_1_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD1_1_3": $("#txtFIELD1_1_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD1_1_4": $("#txtFIELD1_1_4").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD1_1_5": $("#txtFIELD1_1_5").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD1_1_6": $("#txtFIELD1_1_6").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD1_1_7": $("#txtFIELD1_1_7").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "COMMENTSECTION1": $("#txtFIELD_1_Comments").val(f.value); break;
//            case "FIELD1_2_1": $("#txtFIELD1_2_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD1_2_2": $("#txtFIELD1_2_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD1_2_3": $("#txtFIELD1_2_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD1_2_4": $("#txtFIELD1_2_4").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD1_2_5": $("#txtFIELD1_2_5").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD2_1_1": $("#txtFIELD2_1_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD2_1_2": $("#txtFIELD2_1_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD2_2_1": $("#txtFIELD2_2_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD2_2_1_1": $("#txtFIELD2_2_1_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD2_2_1_2": $("#txtFIELD2_2_1_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD2_2_1_3": $("#txtFIELD2_2_1_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD2_2_2": $("#txtFIELD2_2_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD2_2_2_1": $("#txtFIELD2_2_2_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD2_2_2_2": $("#txtFIELD2_2_2_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD2_2_2_3": $("#txtFIELD2_2_2_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "COMMENTSECTION2": $("#txtFIELD_2_Comments").val(f.value); break;
//            case "FIELD3_1": $("#txtFIELD3_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD3_2": $("#txtFIELD3_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "COMMENTSECTION3": $("#txtFIELD_3_Comments").val(f.value); break;
//            case "FIELD4_1_1": $("#txtFIELD4_1_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_1_2": $("#txtFIELD4_1_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_1_3": $("#txtFIELD4_1_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_1_4_1": $("#txtFIELD4_1_4_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_1_4_2": $("#txtFIELD4_1_4_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_1_4_3": $("#txtFIELD4_1_4_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_1_5_1": $("#txtFIELD4_1_5_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_1_5_2": $("#txtFIELD4_1_5_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_1_5_3": $("#txtFIELD4_1_5_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_1_6_1": $("#txtFIELD4_1_6_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_1_6_2": $("#txtFIELD4_1_6_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_1_6_3": $("#txtFIELD4_1_6_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_2_1": $("#txtFIELD4_2_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_2_2": $("#txtFIELD4_2_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_2_3": $("#txtFIELD4_2_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_2_4_1": $("#txtFIELD4_2_4_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_2_4_2": $("#txtFIELD4_2_4_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_2_4_3": $("#txtFIELD4_2_4_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_2_5_1": $("#txtFIELD4_2_5_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_2_5_2": $("#txtFIELD4_2_5_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_2_5_3": $("#txtFIELD4_2_5_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_2_6_1": $("#txtFIELD4_2_6_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_2_6_2": $("#txtFIELD4_2_6_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_2_6_3": $("#txtFIELD4_2_6_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_3_1": $("#txtFIELD4_3_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_3_2": $("#txtFIELD4_3_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_3_3": $("#txtFIELD4_3_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_3_4_1": $("#txtFIELD4_3_4_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_3_4_2": $("#txtFIELD4_3_4_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_3_4_3": $("#txtFIELD4_3_4_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_3_5_1": $("#txtFIELD4_3_5_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_3_5_2": $("#txtFIELD4_3_5_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_3_5_3": $("#txtFIELD4_3_5_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_3_6_1": $("#txtFIELD4_3_6_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_3_6_2": $("#txtFIELD4_3_6_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD4_3_6_3": $("#txtFIELD4_3_6_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "COMMENTSECTION4": $("#txtFIELD_4_Comments").val(f.value); break;
//            case "FIELD5_1": $("#txtFIELD5_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD5_2": $("#txtFIELD5_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD5_3": $("#txtFIELD5_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD5_4": $("#txtFIELD5_4").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "COMMENTSECTION5": $("#txtFIELD_5_Comments").val(f.value); break;
//            case "FIELD6_1_1": $("#txtFIELD6_1_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD6_1_2": $("#txtFIELD6_1_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD6_1_3": $("#txtFIELD6_1_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD6_2_1": $("#txtFIELD6_2_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD6_2_2": $("#txtFIELD6_2_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD6_2_3": $("#txtFIELD6_2_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD6_3_1": $("#txtFIELD6_3_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD6_3_2": $("#txtFIELD6_3_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD6_3_3": $("#txtFIELD6_3_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "COMMENTSECTION6": $("#txtFIELD_6_Comments").val(f.value); break;
//            case "FIELD7_1_1": $("#txtFIELD7_1_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD7_1_2": $("#txtFIELD7_1_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD7_1_3": $("#txtFIELD7_1_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "COMMENTSECTION7": $("#txtFIELD_7_Comments").val(f.value); break;
//            case "FIELD8_1": $("#txtFIELD8_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD8_2": $("#txtFIELD8_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD8_3": $("#txtFIELD8_3").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "COMMENTSECTION8": $("#txtFIELD_8_Comments").val(f.value); break;
//            case "FIELD9_1": $("#txtFIELD9_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD9_2": $("#txtFIELD9_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "COMMENTSECTION9": $("#txtFIELD_9_Comments").val(f.value); break;
//            case "FIELD10_1": $("#txtFIELD10_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "COMMENTSECTION10": $("#txtFIELD_10_Comments").val(f.value); break;
//            case "FIELD11_1": $("#txtFIELD11_1").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "FIELD11_2": $("#txtFIELD11_2").val(($.trim(f.value) !== "") ? Math.floor(Number(f.value)) : ""); break;
//            case "COMMENTSECTION11": $("#txtFIELD_11_Comments").val(f.value); break;
//        }
//    });

//    //enableDisableReview();

//    $('#draftFound').modal('hide');
//}

//function retrieveExisting() {
//    var courtName = document.getElementById("txtCOURT").value;
//    var reportingYear = document.getElementById("intREPORTINGYEAR").value;
//    var retrieveObj = {
//        "appId": "CAACS",
//        "region": "NEWRECORD",
//        "summaryPage": {
//            "pageSize": 1,
//            "pageNumber": 1,
//            "offset": 0,
//            "pageCount": 0,
//            "sortFieldName": "DOCKET",
//            "sortDirection": "DESC",
//            "showRestrictedItems": true
//        },
//        "searchParams": [
//            {
//                "fieldName": "STATUS",
//                "operator": "EQUAL",
//                "values": [
//                    "COMPLETED"
//                ]
//            },
//            {
//                "fieldName": "COURT",
//                "operator": "EQUAL",
//                "values": [
//                    courtName
//                ]
//            },
//            {
//                "fieldName": "REPORTINGYEAR",
//                "operator": "EQUAL",
//                "values": [
//                    reportingYear
//                ]
//            }
//        ]
//    }

//    $.ajax({
//        url: $("#apiUrlRetrieve").val(),
//        type: 'POST',
//        data: JSON.stringify(retrieveObj), // convert to JSON
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',
//        success: function (response) {
//            console.log(response);
//            //retrievedRecord = response;
//            //var data = retrievedRecord;

//            //const rootKey = Object.keys(data)[0];
//            //const childKey = Object.keys(data[rootKey])[0];

//            /*const guid = data[response][childKey][0].guid;*/
//            if (Object.keys(response)[0] != null) {
//                $('#alreadyExists').modal('show');
//                $("#tabsbar").attr('hidden', true);
//                $("#btnSave").attr('hidden', true);
//                $("#btnNext").attr('hidden', true);
//                return true;
//            }
//            else {
//                retrieveDraft();
//                $("#tabsbar").removeAttr('hidden');
//                $("#btnNext").removeAttr('hidden');
//            }
//            return false;
//        },
//        error: function (err) {
//            //console.error(err);
//            $('#draftRetrievalFailed').modal('show');
//            //alert("The draft save failed");
//        }
//    });
//}

function hideAlreadyExists() {
    $('#alreadyExists').modal('hide');
}

window.addEventListener("load", function () {
    console.log("Page is fully loaded");
    $('#sidebarMessage').delay(3000).fadeOut(400);
    $(".breadcrumb").children().first().remove();
    const params = new URLSearchParams(window.location.search);
    const recSaved = params.get("submitForSave");
    if (recSaved != null) {
        $("#tabsbar").removeAttr('hidden');
        $("#btnNext").removeAttr('hidden');
        draftSuccessfullySaved();
        const secId = document.getElementById("sectionIdFromCreate").value;
        focusOnFormFromCreate(secId);
        $("#btnSave").removeAttr('hidden');
        $("#txtCOURT").on("mousedown keydown", function (e) {
            e.preventDefault();
        });
        $("#intREPORTINGYEAR").on("mousedown keydown", function (e) {
            e.preventDefault();
        });
    }
    const completedFound = params.get("completedFound");
    if (completedFound != null) {
        showAlreadyExists();
    }
    const draftRecFound = params.get("draftFound");
    if (draftRecFound != null) {
        retrieveDraft();
    }
    const loadRec = params.get("loadRecord");
    if (loadRec != null) {
        $("#tabsbar").removeAttr('hidden');
        $("#btnNext").removeAttr('hidden');
        $("#btnSave").removeAttr('hidden');
        $("#txtCOURT").on("mousedown keydown", function (e) {
            e.preventDefault();
        });
        $("#intREPORTINGYEAR").on("mousedown keydown", function (e) {
            e.preventDefault();
        });
    }
    const deleteDraft = params.get("deleteDraft");
    if (deleteDraft != null) {
        $("#tabsbar").removeAttr('hidden');
        $("#btnNext").removeAttr('hidden');
        $("#btnSave").removeAttr('hidden');
    }
    const noDraft = params.get("noDraft");
    if (noDraft != null) {
        $("#tabsbar").removeAttr('hidden');
        $("#btnNext").removeAttr('hidden');
        $("#btnSave").removeAttr('hidden');
        $("#txtCOURT").attr("readonly", true);
        $("#intREPORTINGYEAR").attr("readonly", true);
        $("#txtCOURT").on("mousedown keydown", function (e) {
            e.preventDefault();
        });
        $("#intREPORTINGYEAR").on("mousedown keydown", function (e) {
            e.preventDefault();
        });
    }
    const deleted = params.get("deleted");
    if (deleted != null) {
        hideFoundModal();
        $("#tabsbar").removeAttr('hidden');
        $("#btnNext").removeAttr('hidden');
        $("#btnSave").removeAttr('hidden');
        $("#txtCOURT").on("mousedown keydown", function (e) {
            e.preventDefault();
        });
        $("#intREPORTINGYEAR").on("mousedown keydown", function (e) {
            e.preventDefault();
        });
    }
    const handlerLoad = params.get("handler");
    if (handlerLoad != null && handlerLoad == "Load") {
        //$("#tabsbar").removeAttr('hidden');
        //$("#btnNext").removeAttr('hidden');
        //$("#btnSave").removeAttr('hidden');
        $("#txtCOURT").on("mousedown keydown", function (e) {
            e.preventDefault();
        });
        $("#intREPORTINGYEAR").on("mousedown keydown", function (e) {
            e.preventDefault();
        });
    }
    if (document.getElementById("intREPORTINGYEAR") != null) {
        const year = document.getElementById("intREPORTINGYEAR").value;
        if (!year) return;

        const dtFrom = document.getElementById("dtFROM");
        const dtTo = document.getElementById("dtTO");

        dtFrom.setAttribute("max", `${year}-12-31`);
        dtTo.setAttribute("min", `${year}-01-01`);
        dtTo.setAttribute("max", `${year}-12-31`);

        console.log(dtFrom.max);
        console.log(dtTo.min);
        console.log(dtTo.max);
    }

    if ((document.getElementById("intREPORTINGYEAR") != null)
        && (document.getElementById("txtCOURT") != null)
    ) {
        $("#dtFROM").attr("readonly", true);
        $("#dtTO").attr("readonly", true);
    }
});

document.addEventListener('DOMContentLoaded', function () {
    const tooltipTriggerList = [].slice.call(
        document.querySelectorAll('[data-bs-toggle="tooltip"]')
    );

    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
});

document.querySelectorAll('[data-bs-toggle="tooltip"]').forEach(el => {
    new bootstrap.Tooltip(el, {
        html: true,
        container: 'body',
        boundary: 'viewport',
        fallbackPlacements: ['top', 'bottom', 'left', 'right'],
        popperConfig(defaultBsPopperConfig) {
            return {
                ...defaultBsPopperConfig,
                modifiers: [
                    ...defaultBsPopperConfig.modifiers,
                    {
                        name: 'preventOverflow',
                        options: {
                            boundary: 'viewport'
                        }
                    }
                ]
            };
        }
    });
});