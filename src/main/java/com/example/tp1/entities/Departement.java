package com.example.tp1.entities;

import javax.persistence.*;
import java.io.Serializable;


@Entity
@Table(name="Departement")
public class Departement implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_depart", nullable = false)
    private int idDepart;

    public int getIdDepart() {
        return idDepart;
    }

    public void setIdDepart(int idDepart) {
        this.idDepart = idDepart;
    }

    @Column(name = "nom_deaprt",nullable = false)
    private String nomDepart;

    public String getNomDepart() {
        return nomDepart;
    }

    public void setNomDepart(String nomDepart) {
        this.nomDepart = nomDepart;
    }

}
