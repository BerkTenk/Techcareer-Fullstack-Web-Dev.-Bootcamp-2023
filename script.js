function Ekle(){
    var alisverisEkle = document.getElementById("alisverisEkle");
    var liste = document.getElementById("liste");
    var yeniOge = document.createElement("li");
    var sil = document.createElement("button");
    yeniOge.innerText = alisverisEkle.value;

    if(alisverisEkle.value !== ""){
        liste.appendChild(yeniOge);
        liste.appendChild(sil);
        alisverisEkle.value = "";

        yeniOge.onclick = function(){
            var yeniMetin = prompt("yeni değer gir");
            if(yeniMetin !== "" && yeniMetin !== null){
                this.firstChild.nodeValue = yeniMetin;
            }
        }
        sil.addEventListener("click",function(e){
            e.preventDefault();
            this.parentNode.removeChild(yeniOge);
            this.parentNode.removeChild(sil);
        });
    } else{
        alert("lütfen bir öğe giriniz!")
    }
}

function listeTemizle(){
    var liste = document.getElementById("liste");
    liste.innerHTML = "";
}