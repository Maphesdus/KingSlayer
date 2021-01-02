// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "KSHealthComponent.generated.h"

//On health changed event
DECLARE_DYNAMIC_MULTICAST_DELEGATE_SixParams(FOnHealthChangedSignature, UKSHealthComponent*, HealthComp, float, Health, float, HealthDelta, const class UDamageType*, DamageType, class AController*, InstigatedBy, AActor*, DamageCauser);

UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class KINGSLAYER_API UKSHealthComponent : public UActorComponent
{
	GENERATED_BODY()

public:	
	// Sets default values for this component's properties
	UKSHealthComponent();

protected:
	// Called when the game starts
	virtual void BeginPlay() override;
	UPROPERTY(BlueprintReadOnly, Category = "Status")
	bool bIsDead;

	UPROPERTY(Replicated, BlueprintReadOnly, Category = "HealthSystem")
	float Health;

	UPROPERTY(EditAnywhere, BlueprintReadOnly, Category = "HealthSystem")
	float MaxHealth;

	UFUNCTION()
	void HandleTakeDamage(AActor* DamagedActor, float Damage, const class UDamageType* DamageType, class AController* InstigatedBy, AActor* DamageCauser);

public:	

	float GetHealth() const;

	UPROPERTY(BlueprintAssignable, Category = "HealthSystem")
	FOnHealthChangedSignature OnHealthChanged;	
};
