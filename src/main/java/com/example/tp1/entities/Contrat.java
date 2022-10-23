package com.example.tp1.entities;

import lombok.Getter;
import lombok.Setter;

import javax.persistence.*;
import java.io.Serializable;
import java.util.Date;


@Entity
@Table(name="Contrat")
@Getter
@Setter
public class Contrat implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_contrat", nullable = false)
    private int idContrat;


    @Column(name = "date_debut_contrat", nullable = false)

    @Temporal(TemporalType.DATE)
    private Date dateDebutContrat;

    public Date getDateDebutContrat() {
        return dateDebutContrat;
    }

    public void setDateDebutContrat(Date dateDebutContrat) {
        this.dateDebutContrat = dateDebutContrat;
    }

    @Column(name = "date_fin_contrat", nullable = false)

    @Temporal(TemporalType.DATE)
    private Date dateFinContrat;

    public Date getDateFinContrat() {
        return dateFinContrat;
    }

    public void setDateFinContrat(Date dateFinContrat) {
        this.dateFinContrat = dateFinContrat;
    }

    @Column(name = "specialite", nullable = false)

    @Enumerated(EnumType.STRING)
    private Specialite specialite;

    public Specialite getSpecialite() {
        return specialite;
    }

    public void setSpecialite(Specialite specialite) {
        this.specialite = specialite;
    }

    @Column(name = "archive", nullable = false)
    private Boolean archive;

    public Boolean getArchive() {
        return archive;
    }

    public void setArchive(Boolean archive) {
        this.archive = archive;
    }

    @Column(name = "montant_contrat", nullable = false)
    private int montantContrat;
    public int getMontantContrat() {
        return montantContrat;
    }

    public void setMontantContrat(int montantContrat) {
        this.montantContrat = montantContrat;
    }
}
