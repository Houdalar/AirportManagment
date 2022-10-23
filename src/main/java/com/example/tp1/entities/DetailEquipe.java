package com.example.tp1.entities;

import javax.persistence.*;
import java.io.Serializable;


@Entity
@Table(name="Detail_Equipe")
public class DetailEquipe implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_detail_equipe", nullable = false)
    private int idDetailEquipe;

    public int getIdDetailEquipe() {
        return idDetailEquipe;
    }

    public void setIdDetailEquipe(int idDetailEquipe) {
        this.idDetailEquipe = idDetailEquipe;
    }

    @Column(name = "salle", nullable = false)
    private int salle;

    public int getSalle() {
        return salle;
    }

    public void setSalle(int salle) {
        this.salle = salle;
    }

    @Column(name = "thematique", nullable = false)
    private int thematique;

    public int getThematique() {
        return thematique;
    }

    public void setThematique(int thematique) {
        this.thematique = thematique;
    }

}
