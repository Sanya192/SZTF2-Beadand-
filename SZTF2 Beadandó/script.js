var chosen = "x";
function select(id) {
    var blokk = document.getElementById("blokk");
    blokk.innerHTML = id + ".Locsolo";
    document.getElementById("szam").value = id;
    chosen = id;
    var adat=document.getElementById(id);
	var field=document.getElementById('csap');
	field.innerHTML="";
    for(var i=0;i<adat.dataset.kivmenny;i++){
    var radioInput=document.createElement("input");
	radioInput.setAttribute('type', 'radio');
	radioInput.setAttribute('name', 'csap');
	radioInput.setAttribute('value',i)
    field.appendChild(radioInput);
}
    //state();
}
/*function state() {
    var com = document.getElementById("COM");
    var player = document.getElementById("P1");
    var win = document.getElementById("win");
    var diff = document.getElementById("diff");
    var comScore = 0;
    var playerScore = 0;
    var palantak = document.getElementsByName("Palanta");
    for (var i = 0; i < palantak.length; i++) {
        if (palantak[i].dataset.owner === "False") {
            playerScore += parseInt(palantak[i].dataset.vizhozam);
        }
        else {
            comScore += parseInt(palantak[i].dataset.vizhozam);

        }
    }
    com.innerHTML = comScore;
    player.innerHTML = playerScore;
    if (comScore > playerScore) {
        win.innerHTML="Számítógép";
    }
    else if(comScore<playerScore){
        win.innerHTML="Játékos";
    }
    else {
        win.innerHTML = "Döntetlen";
    }
    diff.innerHTML = Math.abs(comScore - playerScore)
}*/
