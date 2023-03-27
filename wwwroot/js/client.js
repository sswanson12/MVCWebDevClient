$(function(){
    $(".discountToastButton").on('click', showToast);
});

function showToast(e){
    e.preventDefault();
    
    var toast = new Audio('media/toast.wav');


    // first pause the audio (in case it is still playing)
    toast.pause();

    // reset the audio
    toast.currentTime = 0;

    // play audio
    toast.play();

    let code = $(e.currentTarget).data('code')
    let productName = $(e.currentTarget).data('product')
    let discount = $(e.currentTarget).data('discount')
    
    $('#discountPercent').html(discount);

    $('#code').html(code);

    $('#product').html(productName);

    $('#discountToast').toast({ autohide: false }).toast('show');

    document.onkeydown = function(e) {
        if (e.key === 'Escape'){
            $('#discountToast').toast('hide');
        }
    };
}
