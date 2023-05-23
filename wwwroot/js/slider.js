let currentSlideIndex = 1;
let slides = document.getElementsByClassName('slide');
let dots = document.getElementsByClassName('dot');
let slideCount = slides.length;
// initialize slides
showSlides(currentSlideIndex);
// initialize interval
let slideTimer = setInterval(() => {
    plusSlides(1);
}, 5000);

function resetSlideInterval() {
    clearInterval(slideTimer);
    slideTimer = setInterval(() => {
        plusSlides(1);
    }, 5000);
}
// Next/previous controls
function plusSlides(next) {
    resetSlideInterval();
    showSlides(currentSlideIndex += next);
}
// controls for the dots
function currentSlide(slideIndex) {
    resetSlideInterval();
    showSlides(currentSlideIndex = slideIndex);
}

function showSlides(slideIndex) {
    let i;
    if (currentSlideIndex > slideCount) {
        currentSlideIndex = 1;
    } else if (currentSlideIndex < 1) {
        currentSlideIndex = slideCount;
    }

    for (i = 0; i < slideCount; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace('active', '');
    }
    slides[currentSlideIndex - 1].style.display = 'block';
    dots[currentSlideIndex - 1].classList.add('active');
}
