package com.example.tp1.entities;

import javax.persistence.*;
import java.io.Serializable;


@Entity
@Table(name="Equipe")
public class Equipe implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_equipe", nullable = false)
    private int idEquipe;

    public int getIdEquipe() {
        return idEquipe;
    }

    public void setIdEquipe(int idEquipe) {
        this.idEquipe = idEquipe;
    }

    @Column(name = "nom_equipe",nullable = false)
    private String nomEquipe;

    public String getNomEquipe() {
        return nomEquipe;
    }

    public void setNomEquipe(String nomEquipe) {
        this.nomEquipe = nomEquipe;
    }

    @Column(name = "niveau",nullable = false)

    @Enumerated(EnumType.STRING)
    private Niveau niveau;

    public Niveau getNiveau() {
        return niveau;
    }

    public void setNiveau(Niveau niveau) {
        this.niveau = niveau;
    }

}
