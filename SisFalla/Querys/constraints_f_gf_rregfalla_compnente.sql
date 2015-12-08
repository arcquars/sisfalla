
BEGIN 

Execute Immediate 'delete F_Gf_Rregfalla_Componente where not (PK_COD_FALLA , Pk_Origen_Informe , Pk_D_Cod_Tipoinforme ) in (select PK_COD_FALLA , Pk_Origen_Informe , Pk_D_Cod_Tipoinforme  From F_GF_INFORMEFALLA)';


Execute Immediate 'Alter Table F_Gf_Rregfalla_Componente Drop Constraint F_Gf_Rregfalla_Componente_Fk1 ';

Execute Immediate 'Alter Table F_Gf_Rregfalla_Componente Drop Constraint F_Gf_Rregfalla_Componente_Fk2 ';


Execute Immediate 'ALTER TABLE F_GF_RREGFALLA_COMPONENTE ADD CONSTRAINT F_GF_RREGFALLA_COMPONENTE_FK3 FOREIGN KEY (   PK_COD_FALLA , PK_ORIGEN_INFORME , PK_D_COD_TIPOINFORME )REFERENCES F_GF_INFORMEFALLA (   PK_COD_FALLA , PK_ORIGEN_INFORME , PK_D_COD_TIPOINFORME )ON DELETE CASCADE ENABLE';
 

END ;