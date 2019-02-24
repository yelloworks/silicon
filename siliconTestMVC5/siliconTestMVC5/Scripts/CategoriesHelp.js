function CutString(text) {
    var slecedText = text.slice(0, 150);
    if (slecedText.length < text.length) {
        return slecedText;
    }
    return text;
}

function ShowPopup(element) {
    element.classList.toggle("show");
}

function GeneratePopupId(parentName) {
    return (parentName + "Popup");
}
