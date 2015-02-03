function drag(elementToDrag,event)
{
     //设置要移动的初始化对象
        var drag = document.createElement("div_move")
        drag.style.position = "absolute";
        drag.style.zIndex = elementToDrag.style.zIndex - 1;
        drag.innerHTML  = "";
        drag.style.cursor  = "move";
        drag.style.border  = "1 solid black";
        drag.style.textAlign  = "center";
        drag.style.backgroundColor="#e6e2d9"; 
        drag.style.backgroundRepeat="repeat"; 
        drag.style.backgroundAttachment="scroll"; 
        drag.style.borderLeft="5px solid #000000"; 
        drag.style.borderRight="5px solid #000000"; 
        drag.style.borderTop="5px solid #000000"; 
        drag.style.borderBottom="5px solid #000000"; 
        drag.style.display = "none";
        drag.style.width = elementToDrag.offsetWidth;
        drag.style.height = elementToDrag.offsetHeight;
        drag.style.top = elementToDrag.offsetTop;
        drag.style.left = elementToDrag.offsetLeft;
        drag.style.filter="alpha(opacity=20)";
        document.body.insertBefore(drag);
        window.drag_move = drag;     //把移动对象保存到全局变量中

    
    window.drag_move.style.display = "block";
    
    
    
    
    var startX = event.clientX,startY = event.clientY;
    
    var origX = elementToDrag.offsetLeft,origY = elementToDrag.offsetTop;
    
    var deltaX = startX - origX,deltaY = startY - origY;
    
    if(document.addEventListener)
    {
        document.addEventListener("mousemove",moveHandler,true);
        document.addEventListener("mouseup",upHandler,true);
    }
    else if(document.attachEvent)
    {
        window.drag_move.setCapture();
        window.drag_move.attachEvent("onmousemove",moveHandler);
        window.drag_move.attachEvent("onmouseup",upHandler);
        window.drag_move.attachEvent("onlosecapture",upHandler);
    }
    else
    {
        var oldmovehandler = document.onmousemove;
        var olduphandler = document.onmouseup;
        document.onmousemove = moveHandler;
        document.onmoouseup = upHandler;
    }
    if(event.stopPropagation) event.stopPropagation();
    else event.cancelBubble = true;
    
    if(event.preventDefault) event.preventDefault();
    else event.returnValue = false;
    
    function moveHandler(e)
    {
        if(!e) e = window.event;
        window.drag_move.style.left = (e.clientX - deltaX) + "px";
        window.drag_move.style.top = (e.clientY - deltaY) + "px";
        
        if(window.drag_move.offsetLeft < 0)
	    {
	        window.drag_move.style.left = 0;
	    }
	    if ((window.drag_move.offsetLeft + window.drag_move.offsetWidth) > parseInt(document.body.clientWidth,10)) {
			window.drag_move.style.left = parseInt(document.body.clientWidth,10) - window.drag_move.offsetWidth + 10;
		}
	    if(window.drag_move.offsetTop < 0)
	    {
	        window.drag_move.style.top = 0;
	    }
	    
        
        if(e.stopPropagation) e.stopPropagation();
        else e.cancelBubble = true;
    }
    function upHandler(e)
    {
        if(!e) e = window.event;
        elementToDrag.style.left = window.drag_move.offsetLeft;
        elementToDrag.style.top = window.drag_move.offsetTop;
        //window.drag_move.style.display = "none";
        this.top.document.body.removeChild(window.drag_move);
        if(document.removeEventListener)
        {
            document.removeEventListener("mouseup",upHandler,true);
            document.removeEventListener("mousemove",moveHandler,true);
        }
        else if(document.detachEvent)
        {
           window.drag_move.detachEvent("onlosecapture",upHandler);
           window.drag_move.detachEvent("onmouseup",upHandler);
           window.drag_move.detachEvent("onmousemove",moveHandler);
           window.drag_move.releaseCapture();
        }
        else
        {
            document.onmouseup = olduphandler;
            document.onmousemove = oldmovehandler;
        }
        if(e.stopPropagation) e.stopPropagation();
        else e.cancelBubble = true;
    }
}