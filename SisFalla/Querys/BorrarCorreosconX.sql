BEGIN 
Execute Immediate 'delete F_Ap_Rcontacto where upper (email) like ''%X'' ';
END ;