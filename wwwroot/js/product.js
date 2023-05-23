const thumbnails = document.getElementsByClassName('thumbnail');
const fullImage = document.getElementById('fullImage');
const fullImageContainer = document.getElementById('fullImageContainer');

// Attach click event listeners to each thumbnail
for (let i = 0; i < thumbnails.length; i++) {
    const thumbnail = thumbnails[i];

    thumbnail.addEventListener('click', function () {
        // Remove the active class from all thumbnails
        for (let j = 0; j < thumbnails.length; j++) {
            thumbnails[j].classList.remove('active');
        }

        // Add the active class to the clicked thumbnail
        this.classList.add('active');

        // Get the source of the clicked thumbnail
        const thumbnailSrc = this.src;

        // Update the full image source with the clicked thumbnail source
        fullImage.src = thumbnailSrc;
    });
}
// Attach mousemove event listener to the full image container
fullImageContainer.addEventListener('mousemove', function (event) {
    // Get the position of the mouse within the container
    const containerRect = fullImageContainer.getBoundingClientRect();
    const mouseX = event.clientX - containerRect.left;
    const mouseY = event.clientY - containerRect.top;

    // Calculate the zoomed position and update the image
    const zoomedX = (mouseX / fullImageContainer.clientWidth) * 100;
    const zoomedY = (mouseY / fullImageContainer.clientHeight) * 100;
    fullImage.style.transformOrigin = `${zoomedX}% ${zoomedY}%`;
});

// Attach mouseenter event listener to the full image container
fullImageContainer.addEventListener('mouseenter', function () {
    // Add the 'zoomed' class to apply the zoom effect
    fullImage.classList.add('zoomed');
});

// Attach mouseleave event listener to the full image container
fullImageContainer.addEventListener('mouseleave', function () {
    // Remove the 'zoomed' class to reset the image
    fullImage.classList.remove('zoomed');
});
