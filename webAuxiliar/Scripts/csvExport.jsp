<%
    response.setContentType("application/vnd.ms-excel");
    String buf=request.getParameter("csvBuffer");
    try{response.getWriter().println(buf);}catch(Exception e){}
%>