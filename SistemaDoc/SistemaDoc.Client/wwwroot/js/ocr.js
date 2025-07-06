 async function recognizeTextFromImage(fileInputId) {
    const { createWorker } = Tesseract;
    const input = document.getElementById(fileInputId);
    const file = input.files[0];
    const imageURL = URL.createObjectURL(file);

    const worker = await createWorker('eng');
    const { data: { text } } = await worker.recognize(imageURL);
    return text;
}
