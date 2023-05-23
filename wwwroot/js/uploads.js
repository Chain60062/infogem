// Get the image uploader input element
const imageUploader = document.getElementById('fileUploadImages');

// Get the file names container element
const fileNamesContainer = document.getElementById('fileNamesContainer');

// Add change event listener to the image uploader
imageUploader.addEventListener('change', function () {
    // Clear the file names container
    fileNamesContainer.innerHTML = '';

    // Get the selected files
    const files = Array.from(imageUploader.files);

    // Display the file names in the container
    files.forEach(file => {
        console.log(file.name)
        const fileName = document.createElement('span');
        fileName.classList.add('file-name')
        fileName.textContent = file.name;
        fileNamesContainer.appendChild(fileName);
    });
});
