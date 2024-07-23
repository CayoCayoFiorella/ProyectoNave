using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SistemaGuardado : MonoBehaviour
{
    private string archivo;
    public string nombreArchivo;
    public int nivel;
    public DatosJuego datosJuego;
    public CuadroPuntaje cuadroPuntaje;
    public int puntaje= 0;
    private void Awake() {
        archivo= Application.dataPath + "/" + nombreArchivo +".json";
        CargarDatos();
    }

    private void CargarDatos(){
        if(File.Exists(archivo)){
            string contenido= File.ReadAllText(archivo);
            datosJuego= JsonUtility.FromJson<DatosJuego>(contenido);
        }else{
            print("No hay archivo guardado");
        }
    }

    public void GuardarDatos(int iniv){
        if(puntaje > datosJuego.puntajeMax[iniv]){
            datosJuego.puntajeMax[iniv]= puntaje;
        }
        string cadenaJSON= JsonUtility.ToJson(datosJuego);
        File.WriteAllText(archivo,cadenaJSON);
        print("Archivo Guardado");
    }

    public void PutColeccionable(int n){
        datosJuego.coleccionables[n]= true;
    }

    public void AgregarPuntaje(int p){
        puntaje+= p;
        cuadroPuntaje.SetPuntaje(puntaje);
    }

    public void QuitarPuntaje(int p){
        if(p >= puntaje){
            puntaje= 0;
        }else{
            puntaje-= p;
        }
        cuadroPuntaje.SetPuntaje(puntaje);
    }

    public bool TieneTodo(){
        foreach(bool c in datosJuego.coleccionables){
            if(!c){
                return false;
            }
        }
        return true;
    }
}
