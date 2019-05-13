	/*Roll Dice JS*/
var i = 1; 
document.getElementById('rollCubeJs1').style.marginLeft = '420px';
randMinus.onclick = function(){
	if(i>1){
	var divName = "rollCubeJs"+i;
	i=i-1;
	document.getElementById(divName).remove();
	if(i==1)
	{
		document.getElementById('rollCubeJs1').style.marginLeft = '420px';
	}	
	if(i==2)
	{
		document.getElementById('rollCubeJs1').style.marginLeft = '325px';
	}	
	if(i==3)
	{
		document.getElementById('rollCubeJs1').style.marginLeft = '225px';
	}	
	if(i==4)
	{
		document.getElementById('rollCubeJs1').style.marginLeft = '130px';
	}			
	}
};
randPlus.onclick = function(){
	if(i<5){
	i=i+1;
	var nameId = "rollCubeJs"+i;
	var div = document.createElement('div');
	div.className = "rollCube";
	div.id = nameId;
	rollDiceId.insertBefore(div, rollDiceMenuId);
	if(i==2)
	{
		document.getElementById('rollCubeJs1').style.marginLeft = '325px';
	}	
	if(i==3)
	{
		document.getElementById('rollCubeJs1').style.marginLeft = '225px';
	}		
	if(i==4)
	{
		document.getElementById('rollCubeJs1').style.marginLeft = '130px';
	}		
	if(i==5)
	{
		document.getElementById('rollCubeJs1').style.marginLeft = '30px';
	}		
	}
};
randNumb.onclick = function(){
	var n = i;
	for (n;n>0;n--)
	{
		var random = Math.floor(Math.random()*6)+1;
		var way = "rollCubeJs"+n;
		if(random == 1){
		document.getElementById(way).style.backgroundImage = "url('images/dice1.png')";
		}
		else if(random == 2){
		document.getElementById(way).style.backgroundImage = "url('images/dice2.png')";
		}	
		else if(random == 3){
		document.getElementById(way).style.backgroundImage = "url('images/dice3.png')";
		}		
		else if(random == 4){
		document.getElementById(way).style.backgroundImage = "url('images/dice4.png')";
		}		
		else if(random == 5){
		document.getElementById(way).style.backgroundImage = "url('images/dice5.png')";
		}		
		else if(random == 6){
		document.getElementById(way).style.backgroundImage = "url('images/dice6.png')";
		}		
	}
	var audio = new Audio('sounds/rollDice.mp3');
	audio.play();	
};
	/* Arcanoid */
//Pause
var pause = true;	
	
var canvas = document.getElementById("myCanvas");
var ctx = canvas.getContext("2d");
// Ball Coordinates
var x = canvas.width/2;
var y = canvas.height-30;
// Ball offset
var dx = 2;
var dy = -2;
// Score 
var score = 0;
//lives
var lives = 3;
// The Bricks
var brickRowCount = 3;
var brickColumnCount = 5;
var brickWidth = 75;
var brickHeight = 20;
var brickPadding = 10;
var brickOffsetTop = 30;
var brickOffsetLeft = 30;

var bricks = [];
for(var c=0; c<brickColumnCount; c++) {
    bricks[c] = [];
    for(var r=0; r<brickRowCount; r++) {
        bricks[c][r] = { x: 0, y: 0, status: 1 };
    }
}

// Paddle
var paddleHeight = 10;
var paddleWidth = 75;
var paddleX = (canvas.width-paddleWidth)/2;
// Paddle Move
var rightPressed = false;
var leftPressed = false;

var ballRadius = 10;
// Draw Ball
function drawBall() {
    ctx.beginPath();
    ctx.arc(x, y, ballRadius, 0, Math.PI*2);
    ctx.fillStyle = "#a214a0";
    ctx.fill();
    ctx.closePath();
	//Move ball
	if(x + dx > canvas.width-ballRadius || x + dx < ballRadius) {
		dx = -dx;
	}

	if(y + dy < ballRadius) {
		dy = -dy;
	} else if(y + dy > canvas.height-ballRadius) {
		if(x > paddleX && x < paddleX + paddleWidth) {
			dy = -dy;
		}
		else {
				lives--;
				if(!lives) {
					alert("GAME OVER");
					document.location.reload();
				}
				else {
					x = canvas.width/2;
					y = canvas.height-30;
					dx = 2;
					dy = -2;
					paddleX = (canvas.width-paddleWidth)/2;
				}
			}
	}
	x += dx;
    y += dy;		
}
// Draw paddle
function drawPaddle() {
    ctx.beginPath();
    ctx.rect(paddleX, canvas.height-paddleHeight, paddleWidth, paddleHeight);
    ctx.fillStyle = "#a214a0";
    ctx.fill();
    ctx.closePath();
	//Move Paddle
	// Hold paddle on the desk
	if(rightPressed && paddleX < canvas.width-paddleWidth) {
		paddleX += 7;
	}
	else if(leftPressed && paddleX > 0) {
		paddleX -= 7;
	}		
}
//draw Bricks
function drawBricks() {
    for(var c=0; c<brickColumnCount; c++) {
        for(var r=0; r<brickRowCount; r++) {
            if(bricks[c][r].status == 1) {
                var brickX = (c*(brickWidth+brickPadding))+brickOffsetLeft;
                var brickY = (r*(brickHeight+brickPadding))+brickOffsetTop;
                bricks[c][r].x = brickX;
                bricks[c][r].y = brickY;
                ctx.beginPath();
                ctx.rect(brickX, brickY, brickWidth, brickHeight);
                ctx.fillStyle = "#a214a0";
                ctx.fill();
                ctx.closePath();
            }
        }
    }
}
// HANDLERS
document.addEventListener("keydown", keyDownHandler, false);
document.addEventListener("keyup", keyUpHandler, false);
document.addEventListener("mousemove", mouseMoveHandler, false);

// Mouse Paddle handler
function mouseMoveHandler(e) {
    var relativeX = e.clientX - canvas.offsetLeft;
    if(relativeX > 0 && relativeX < canvas.width) {
        paddleX = relativeX - paddleWidth/2;
    }
}
//Right arrow
function keyDownHandler(e) {
    if(e.keyCode == 39) {
        rightPressed = true;
    }
    else if(e.keyCode == 37) {
        leftPressed = true;
    }
    else if(e.keyCode == 80) {
		if(pause == true)
		{
			pause = false;
			
			draw();
		}
		else if(pause == false)
		{
			pause = true;
			
		}
    }
}
//Left arrow
function keyUpHandler(e) {
    if(e.keyCode == 39) {
        rightPressed = false;
    }
    else if(e.keyCode == 37) {
        leftPressed = false;
    }
}

// Draw Scene           !!!! SCENE
function draw() {
	

    ctx.clearRect(0, 0, canvas.width, canvas.height);
    drawBall();
	drawPaddle();
	drawBricks();
	collisionDetection();
	drawScore();
	drawLives();
	drawStage();
	
	if(pause==false){
	requestAnimationFrame(draw);
	}
}

// Collision Detection
function collisionDetection() {
    for(var c=0; c<brickColumnCount; c++) {
        for(var r=0; r<brickRowCount; r++) {
            var b = bricks[c][r];
            if(b.status == 1) {
                if(x > b.x && x < b.x+brickWidth && y > b.y && y < b.y+brickHeight) {
                    dy = -dy;
                    b.status = 0;
					score++;
                    if(score == brickRowCount*brickColumnCount) {
                        alert("YOU WIN, CONGRATULATIONS!");
                        document.location.reload();
                    }					
                }
            }
        }
    }
}
// Draw Score
function drawScore() {
    ctx.font = "16px Arial";
    ctx.fillStyle = "#a214a0";
    ctx.fillText("Score: "+score, 8, 20);
}
// Draw Lives
function drawLives() {
    ctx.font = "16px Arial";
    ctx.fillStyle = "#a214a0";
    ctx.fillText("Lives: "+lives, canvas.width-65, 20);
}
// Draw Stage
// Draw Lives
function drawStage() {
    ctx.font = "16px Arial";
    ctx.fillStyle = "#a214a0";
    ctx.fillText("Pause - p : "+pause, canvas.width-300, 20);
}

draw(); //from request animation







