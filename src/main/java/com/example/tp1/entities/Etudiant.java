package com.example.tp1.entities;

import javax.persistence.*;
import java.io.Serializable;

@Entity
@Table(name="Etudiant")
public class Etudiant implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_etudiant", nullable = false)
    private int idEtudiant;

    public int getIdEtudiant() {
        return idEtudiant;
    }

    public void setIdEtudiant(int idEtudiant) {
        this.idEtudiant = idEtudiant;
    }

    @Column(name = "prenom_etudiant",nullable = false)
    private String prenomE;

    public String getPrenomE() {
        return prenomE;
    }

    public void setPrenomE(String prenomE) {
        this.prenomE = prenomE;
    }

    @Column(name = "nom_etudiant",nullable = false)
    private String nomE;

    public String getNomE() {
        return nomE;
    }

    public void NomE(String nomE) {
        this.nomE = nomE;
    }

    @Column(name = "option",nullable = false)

    @Enumerated(EnumType.STRING)
    private Option option;

    public Option option() {
        return option;
    }

    public void option(Option option) {
        this.option = option;
    }

}
