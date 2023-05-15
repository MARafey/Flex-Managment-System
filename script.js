const submitButton = document.querySelector('input[type="submit"]');

submitButton.addEventListener('mouseover', () => {
    submitButton.classList.add('pulse');
});

submitButton.addEventListener('mouseout', () => {
    submitButton.classList.remove('pulse');
});
