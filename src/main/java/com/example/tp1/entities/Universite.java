package com.example.tp1.entities;

import javax.persistence.*;
import java.io.Serializable;


@Entity
@Table(name="Universite")
public class Universite implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_univ", nullable = false)
    private int idUniv;

    public int getIdUniv() {
        return idUniv;
    }

    public void setIdUniv(int idUniv) {
        this.idUniv = idUniv;
    }

    @Column(name = "nom_univ",nullable = false)
    private String nomUniv;

    public String getNomDUniv() {
        return nomUniv;
    }

    public void setNomUniv(String nomUniv) {
        this.nomUniv = nomUniv;
    }


}
